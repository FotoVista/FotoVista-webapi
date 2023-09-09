namespace FotoVista.Domain.Exceptions.Posts;

public class PostDeleteExeptions : NotFoundException
{
    public PostDeleteExeptions()
    {
        this.TitleMessage = "you do not have permission to delete this post";
    }
}
