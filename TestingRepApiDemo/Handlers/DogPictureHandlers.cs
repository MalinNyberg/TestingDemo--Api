using TestingRepApiDemo.Models.Dtos;
using TestingRepApiDemo.Repositories;
using TestingRepApiDemo.Models;
using System.Net;
using TestingRepApiDemo.Models.ViewModels;

namespace TestingRepApiDemo.Handlers
{
    public static class DogPictureHandlers
    {
        public static IResult AddDogPicture(IDogPictureRepository repository, DogPicturesDto picturesDto, string tag)
        {
            try
            {
                Tag tagObject = repository.GetOrCreateTag(tag);
                DogPicture dbPicture = new DogPicture()
                {
                    Title = picturesDto.Title,
                    Url = picturesDto.Url,
                    Tags = tagObject
                };
                repository.StorePicture(dbPicture);
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in AddDogPicture(): {ex}");
                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult ListTags(IDogPictureRepository repository)
        {
            try
            {
                return Results.Json(repository.ListTags);
            }catch (Exception ex)
            {
                Console.WriteLine($"Error in ListTags(): {ex}");
                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public static IResult GetPicturesForTag(IDogPictureRepository repository, string tag)
        {
            try
            {
                var pictures = repository.ListDogPicturesForTag(tag);
                return Results.Json(pictures.Select(p => new DogPictureViewModel()
                {
                    Title = p.Title,
                    Url = p.Url,
                }));

            }catch(Exception ex)
            {
                Console.WriteLine($"Error in ListDogPicturesForTag(): {ex}");
                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


    }
}
