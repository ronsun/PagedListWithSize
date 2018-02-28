# A sample for pagination with page size and filter

## What's the project for?

This project created for the scenario that need to add list of page size base on [PagedList](https://github.com/troygoode/PagedList). In real world, we often implement pagination and filter in the same time, so I also put a simple fitler in sample pages.

A couple of ways provided to implement list of page size base on PagedList - by **Partial View** or **Customize HtmlHelper**.  

## Dependency
[PagedList](https://github.com/troygoode/PagedList)

## How it looks like?

Three links after launch the project.  
+ **/Home/SampleOriginal** : Samples of original PagedList.
+ **/Home/SampleByPartialView** : Samples of page size list by partial view.
+ **/Home/SampleByHtmlHelper** : Samples of page size list by customize HtmlHelper.

Sample pages looks like:  
![LayoutDemo](https://github.com/ronsun/PagedListWithSize/blob/master/readme/LayoutDemo.png)


## How it work?

### General
+ A css file `PagedListWithSize.css` for stylish.

### Extend by partial view
+ A partial view `_pagedListWithSize.cshtml` with model `PagedListWithSizeModel.cs`, combine PagedList and size in this partial view and use classes defined in `PagedListWithSize.css` for stylish.
+ Defined required properties in the model, include for original PagedList and list of page size.
+ Render the partial view in any view need pagiation, for an example in simple case:

``` csharp
@Html.Partial("_pagedListWithSize",
              new PagedListWithSizeModel()
              {
                  Data = Model.PagedList,
                  GeneratePageUrl = page => Url.Action("SampleByPartialView", new {page}),
                  GenerateSizeUrl = size => Url.Action("SampleByPartialView", new {size});
              })
```

> Note: 
> Please reference sample pages for complex cases.

### Extend by HtmlHelper
+ Implement a customize HtmlHelper for it.
+ Call origianl PagedList in new helper and add something for page size list.
+ Gather required options for page size list into `PagedListSizeRenderOptions.cs` (similar with `PagedListRenderOptions` in original PagedList).

+ Use it just like other HtmlHelpers, simple cases like:
``` csharp
//basic
@Html.PagedListPagerWithSize((IPagedList)Model.PagedList, page => Url.Action("SampleByPartialView", new {page}), size => Url.Action("SampleByPartialView", new {size}))

//with optional argument for PagedList
@Html.PagedListPagerWithSize((IPagedList)Model.PagedList, page => Url.Action("SampleByPartialView", new {page}), size => Url.Action("SampleByPartialView", new {size}), PagedListRenderOptions.Classic)

//with optional argument for page size
@Html.PagedListPagerWithSize((IPagedList)Model.PagedList, page => Url.Action("SampleByPartialView", new {page}), size => Url.Action("SampleByPartialView", new {size}), pageSizeOptions: new PagedListSizeRenderOptions { HeaderText = "Total Pages: " })

//with full arguments
@Html.PagedListPagerWithSize((IPagedList)Model.PagedList, page => Url.Action("SampleByPartialView", new {page}), size => Url.Action("SampleByPartialView", new {size}), PagedListRenderOptions.Classic, new PagedListSizeRenderOptions { HeaderText = "Total Pages: " })

```

> Note: 
> Please reference sample pages for complex cases.
