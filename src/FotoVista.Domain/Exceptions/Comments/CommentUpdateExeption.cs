namespace FotoVista.Domain.Exceptions.Comments;

public class CommentUpdateExeption : NotFoundException
{
    public CommentUpdateExeption()
    {
        this.TitleMessage = "you have permission to Update this comment";
    }
}
