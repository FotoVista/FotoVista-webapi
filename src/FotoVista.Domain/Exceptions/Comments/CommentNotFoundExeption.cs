namespace FotoVista.Domain.Exceptions.Comments;

public class CommentNotFoundExeption : NotFoundException
{
    public CommentNotFoundExeption()
    {
        this.TitleMessage = "Comment not found!";
    }
}