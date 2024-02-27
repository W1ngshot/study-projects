namespace SharedModels;

public interface MessageCreated
{
    int Id { get; set; }

    string Text { get; set; }

    int SomeNumber { get; set; }
}