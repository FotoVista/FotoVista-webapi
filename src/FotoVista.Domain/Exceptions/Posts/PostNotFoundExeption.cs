namespace FotoVista.Domain.Exceptions.Posts;

public class PostNotFoundExeption : NotFoundException
{
    public PostNotFoundExeption()
    {
        this.TitleMessage = "Post not found!";
    }
}
