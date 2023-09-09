namespace FotoVista.Domain.Exceptions.Likes;

public class LikeUpdateExeption : NotFoundException
{
    public LikeUpdateExeption()
    {
        this.TitleMessage = "you have permission to Update this comment";
    }
}
