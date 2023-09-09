namespace FotoVista.Domain.Exceptions.Comments;

public class CommentDeleteExeptions : NotFoundException
{
    public CommentDeleteExeptions()
    {
        this.TitleMessage = "you do not have permission to delete this comment";
    }
}
