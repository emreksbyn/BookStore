# BookStore
Domain
-------------
 Entities 
 
	* Enums -> Status olusturuldu.
	* Interaface -> IBaseEntity ve IBase olusturuldu.
	* Concrete -> Author, Book, BookAuthor, Genre, User olusturuldu.


Application -> Domain katmani referanslara eklendi.
-------------
 Repositories
 
	* BaseRepository -> IBaseRepository olusturuldu
	* Queries -> QueryOptions
	* EntityTypeRepositories (IAuthorRepository, IBookRepository...) olusturuldu.

 UnitOfWork 
 
	IUnitOfWork olusturuldu.
 Grid
 
	* Base -> GridBuilder eklendi.
	 ---> Utilities e RouteDictionary eklendi.
	 ---> DTOs a GridDTO eklendi. Extensions a StringExtensions eklendi. BookGridDTO eklendi. --> Microsoft.AspNetCore.Mvc.NewtonsoftJon indirildi.
	 ---> Utilities e FilterPrefix eklendi.
	 ---> Extensions a SessionExtensions eklendi
	* EntityGrid -> BookGridBuilder eklendi.

Persistence -> Application katmani referanlara eklendi.
--------------
 Context
 
	* AppDbContext olusturuldu Entity' ler DbSet yapildi.
  
 EntityTypeConfigurations
 
	* Abstract -> BaseMap
	* Concrete -> AuthorMap, BookAuthorMap, BookMap, GenreMap, UserMap olusturuldu.
  
 Repositories
 
	* Abstract -> BaseRepository -> Extensions klasorune QueryExtensions eklendi.
	* Concrete -> AuthotRepository, BookRepository...
  
 SeedData
 
	* SeedAuthors, SeedBookAuthor,... Bunları olustur AppDbContext sınıfına ekle.
 
 UnitOfWorkConcrete 
	
  * UnitOfWork -> UnitOfWork yapisini olusturduk. Klasor ile ayni isimde olmasin diye sonuna Concrete ekledim.
 
 DependecyResolver
	
  * AutofacModule -> IoC yi ekledik. Startup sinifina ekledik.
		.UseServiceProviderFactory(new AutofacServiceProviderFactory()) 
		.ConfigureContainer<ContainerBuilder>(builder =>
		{
			builder.RegisterModule(new AutofacModule());
		})

 EntityQueries
	
  * BookQueryOptions eklendi.
 
 Models
	
  * ViewModels -> AuthorListViewModel, BookListViewModel, NavBarViewModel eklendi.


Web -> Application ve Persistence katmanlari referanslara eklendi.
------------

Migration icin -> Web katmanina EFCore.Design paketi indirildi. Persistence katmanina EFCore.SqlServer ve EFCore.Tools paketleri indirildi.
			Package Manager Console da default project migrations klasorunun eklenecegi katman olan Persistence katmani secilir Web katmani Set as Startup Project secilir.
			Startup a AppDbContext eklenir. appsettings.json a ConnectionString eklenir.
			add-migration init1 ve update-database yazilip db ye eklenir.

 Views
	
  * _ViewImports.cshtml -> Entities, Dtos, ViewModels, Utilities ekle.
	* Shared -> _Layout.cshtml duzenle.
 
 Controllers
	
  * Session calismasi icin Startup.cs "services.AddSession();" ve "app.UseSession();" eklendi.
	* BookController eklendi. Views -> List ve Details .cshtml dosyalari eklendi.
	* AuthorController eklendi. Views -> Author -> List.cshtml eklendi.
 
