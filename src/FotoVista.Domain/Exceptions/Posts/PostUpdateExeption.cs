namespace FotoVista.Domain.Exceptions.Posts;

public class PostUpdateExeption : NotFoundException
{
    public PostUpdateExeption()
    {
        this.TitleMessage = "you have permission to Update this post";
    }
}
