namespace FotoVista.Domain.Exceptions.Likes;

public class LikeNotFoundExeption : NotFoundException
{
    public LikeNotFoundExeption()
    {
        this.TitleMessage = "Like not found!";
    }
}
