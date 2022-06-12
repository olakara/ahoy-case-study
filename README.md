# ahoy-case-study is Backend Interview Assessment for AHOY

## Summary

This project is an implementation of assignment requested for AHOY. The application makes use of Clean Architecture inspired by project structure used / demo by Jason Taylor. 
Technologies used are:
 - ASP.NET Core 6
 - Entity Framework Core 6
 - MediatR
 - FluentValidation
 - xUnit, FluentAssertion & Moq

 ## Getting Started

 ## Assumptions

 Since, hotel management is a large domain. I have kept some part of the domain as simple as possible to scope the assignment
 - Rooms : I have not considered room configurations and room type as this will make the domain more bigger.
 - Room Pricing : I have kept a flat rating model.
 - Images Urls are just relative paths. Assumptions is that these images are uploaded using a CMS and they will be published to CDN.
 - Hotel domain is having reivew counts and rating results as accumulated fields. It is assumed that each time new review is submit and approved, system will calculate new scores and increment the review count.
	- This way calculations during the search query is avoided
	- These functionalities can be implemented by domain events. They are not done to have smaller scope
 - I have not considered Authentication & Authorizations in implemenation. Can be implemented using some auth server and JWT

 ## Running the application

 The application