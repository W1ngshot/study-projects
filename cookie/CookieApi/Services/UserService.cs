using System.Security.Claims;
using CookieApi.Database;
using CookieApi.Dto;
using CookieApi.HelperServices;
using CookieApi.Models;
using CookieApi.Repositories;
using FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace CookieApi.Services;

public class UserService : IUserService
{
    private readonly CryptographyService _cryptography;
    private readonly UserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ClaimsIdentityGenerator _claimsIdentityGenerator;
    private readonly IValidator<RegisterDto> _registerValidator;

    public UserService(CryptographyService cryptography,
        UserRepository userRepository,
        IUnitOfWork unitOfWork,
        ClaimsIdentityGenerator claimsIdentityGenerator, 
        DateTimeProvider dateTimeProvider, 
        IValidator<RegisterDto> registerValidator)
    {
        _cryptography = cryptography;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _claimsIdentityGenerator = claimsIdentityGenerator;
        _registerValidator = registerValidator;
    }

    public async Task<ClaimsIdentity> Register(RegisterDto dto)
    {
        await _registerValidator.ValidateAndThrowAsync(dto);
        
        var salt = _cryptography.GenerateSalt();
        var encryptedPassword = _cryptography.EncryptPasswordAsync(dto.Password, salt);

        var user = new User
        {
            Nickname = dto.Nickname,
            PasswordSalt = salt,
            PasswordHash = encryptedPassword,
            Role = "user"
        };

        await _userRepository.AddUserAsync(user);

        return _claimsIdentityGenerator.GenerateUserClaimsIdentity(user);
    }

    public async Task<ClaimsIdentity> Login(LoginDto dto)
    {
        var user = await _userRepository.GetUserByNicknameAsync(dto.Nickname)
            ?? throw new ValidationException("user not found");

        var dtoPasswordHash = _cryptography.EncryptPasswordAsync(dto.Password, user.PasswordSalt);

        if (dtoPasswordHash != user.PasswordHash)
            throw new ValidationException("wrong password");

        return _claimsIdentityGenerator.GenerateUserClaimsIdentity(user);
    }
}