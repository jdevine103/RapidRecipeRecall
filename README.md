# RapidRecipeRecall

By Simply Team 2 (Ben, John & Brittany)

### What is RapidRecipeRecall?

Our application is for an avid home cook to have an easy way to access and store their recipes in one place. No more recipe books or magazine clippings. Users are able to add recipes and create a favorite recipes list. 
They also have the ability to add personal notes to their recipes — if they substituted an ingredient or made a change to the recipe. And all users will also be able to comment (leave reviews, feedback, etc.) on all public recipes.

### User Story

Betty Wiffalsloper is a 45 year old stay at home mom. She is married with three kids and has a dog name Burny. With a busy lifestyle, it is important for Betty to have at least one meal a day together as a family. She loves to cook and searches for new recipes online, and has a stack of her favorite recipe books and magazine clippings. 

Unfortunately, Betty has so many recipe available that she struggles picking one out and spends more time searching for the right recipe than actually cooking. Some nights the family has to settle for a PB&J. She needs an easier way to store and access all of her recipes. The RapidRecipeRecall app is her solution!

## How to run this app locally:
  - You’ll need Visual Studio Community & SQL Server Object Explorer
  - Clone the GitHub repository
  - Use Postman or Swagger (to test endpoints)

### RapidRecipeRecall Wireframe
<img width="738" alt="Screen Shot 2020-09-16 at 4 49 55 PM" src="https://user-images.githubusercontent.com/12259461/93394152-c03ce380-f841-11ea-8cc3-b5ef04ccb63a.png">

![Screen Shot 2020-09-16 at 3 56 18 PM](https://user-images.githubusercontent.com/12259461/93393886-486eb900-f841-11ea-91d8-43529c01c460.png)
  
## Endpoints to test

### Account
  - POST — /api/Account/Register
  - POST — /token

### Recipe
  - POST — /api/Recipe
  - GET — /api/Recipe
  - GET — /api/Recipe/{ID}
  - GET — /api/Recipe?name={name}
  - PUT — api/Recipe/{id}
  - DELETE — api/Recipe/{id}

### UserRecipe
  - POST — /api/UserRecipe
  - GET api/UserRecipe/MyRecipes?id={id}		*{id} is UserId
  - GET api/UserRecipe/MyFavorites?id={id}	*{id} is UserId
  - GET api/UserRecipe/RecipeNotes?id={id}	*{id} is UserRecipeId
  - DELETE api/UserRecipe/{id}

### Note
  - POST — /api/Note
  - PUT — api/Note/{id}
  - DELETE — api/Note/{id}

### Comment
  - POST — /api/Comment
  - GET — api/Comment/{id}	*{id} is RecipeId not CommentId
  - PUT — api/Comment/{id}
  - DELETE — api/Comment/{id}

## Some of the resources/Google searches we used to help us build this app (in no particular order):
  - trello.com
  - miro.com 
  - postman.com 
  - https://docs.microsoft.com/en-us/sql/relational-databases/tables/primary-and-foreign-key-constraints?view=sql-server-ver15 
  - https://stackoverflow.com/questions/7389687/operand-type-clash-uniqueidentifier-is-incompatible-with-int  
  - https://stackoverflow.com/questions/15274539/the-relationship-between-the-two-objects-cannot-be-defined-because-they-are-atta 
  - https://stackoverflow.com/questions/5956326/create-some-sort-of-loop-inside-linq-query
  - https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/?redirectedfrom=MSDN 
  - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators 
  - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/ 
  - http://www.aisoftwarellc.com/blog/post/sql-server-identity-values-jump-by-1000-when-it-is-restarted/2033 
  - https://docs.microsoft.com/en-us/ef/ef6/querying/related-data?redirectedfrom=MSDN 
  - https://social.msdn.microsoft.com/Forums/en-US/444cb716-59be-4b48-b4ef-e6a48fd252c6/c-what-is-the-usage-of-virtual-keyword-in-entity-framework?forum=adodotnetentityframework 
  
