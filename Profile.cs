using FilmAPI.ApiModels;
using FilmAPI.Entity;

namespace FilmAPI;

public class Profile : AutoMapper.Profile
{
    public Profile()
    {
        #region Film

        CreateMap<CreateFilmModel, Film>();
        CreateMap<GetByIdFilmModel, Film>();
        CreateMap<GetByFilmModel, Film>();
        CreateMap<UpdateFilmModel, Film>();

        #endregion
    }
}