namespace FotoVista.Domain.Exceptions.Likes;

public class LikeDeleteExeptions : NotFoundException
{
    public LikeDeleteExeptions()
    {
        this.TitleMessage = "you do not have permission to delete this like";
    }
}
