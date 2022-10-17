// using Backend.DAL_EF;
// using Backend.DataAccessLibrary;
// using Backend.Services.Interface;
// using Backend.Shared.Dtos;
// using Mapster;
//
// namespace Backend.Services.Services;
//
// public class CategoryService : ICategoryService
// {
//     private readonly ApplicationDbContext _applicationDbContext;
//
//     public CategoryService(ApplicationDbContext applicationDbContext)
//     {
//         _applicationDbContext = applicationDbContext;
//     }
//     public IEnumerable<CategoryWithMenuPositionsDto> GetCategoryWithMenuPositionsByServicePointId(int userId)
//     {
//         var servicePointId = _applicationDbContext.Users.Where(x => x.Id.Equals(userId)).Select(x => x.ServicePointId)
//             .First();
//         var categoryPositions =
//             _applicationDbContext.CategoryPositions
//                 .Where(x=>x.ServicePointId.Equals(servicePointId))
//                 .Select(x=>x.CategoryId).Distinct().ToList();
//         
//         var CaTegoryWithMenuPositionsList = new List<CategoryWithMenuPositionsDto>();
//         foreach (var categoryPositionId in categoryPositions)
//         {
//             CategoryWithMenuPositionsDto categoryWithMenuPositionsDto = new CategoryWithMenuPositionsDto();
//             categoryWithMenuPositionsDto.Category = _applicationDbContext.Categories
//                 .FirstOrDefault(x => x.Id.Equals(categoryPositionId)).Adapt<CategoryDto>();
//             var listOfInt =
//                 _applicationDbContext.CategoryPositions
//                     .Where(x=>x.CategoryId.Equals(categoryPositionId))
//                     .Select(x=>x.MenuPositionId).ToList();
//             categoryWithMenuPositionsDto.MenuPosition =
//                 _applicationDbContext.MenuPositions.Where(x => listOfInt.Contains(x.Id)).ToList()
//                     .Adapt<List<MenuPositionDto>>();
//             CaTegoryWithMenuPositionsList.Add(categoryWithMenuPositionsDto);
//         }
//
//         return CaTegoryWithMenuPositionsList;
//     }
//
//     public void AddCategory(int userId, string categoryName)
//     {
//         var servicePointId = _applicationDbContext.Users.Where(x => x.Id.Equals(userId)).Select(x => x.ServicePointId)
//             .First();
//         var newCategory = new Category()
//         {
//             Name = categoryName,
//             ServicePointId = servicePointId
//         };
//         if (!_applicationDbContext.Categories.Any(x =>
//                 x.Name.Equals(categoryName) && x.ServicePointId.Equals(servicePointId)))
//         {
//             _applicationDbContext.Categories.Add(newCategory);
//             _applicationDbContext.SaveChanges();    
//         }
//         else
//         {
//             throw new Exception("category with that name already exists");
//         }
//         
//     }
//
//     public void EditCategory(int categoryId, string newCategoryName)
//     {
//         var category = _applicationDbContext.Categories.First(x => x.Id.Equals(categoryId));
//         category.Name = newCategoryName;
//         _applicationDbContext.Orders.Update()
//         _applicationDbContext.SaveChanges();
//     }
//
//     public string GetTypeName_(int id)
//     {
//         return _applicationDbContext.OrderTypes.FirstOrDefault(x => x.Id.Equals(id)).TypeName;
//     }
// }