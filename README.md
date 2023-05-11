# wepAPI
This is a server side project on management system Corona for a large health fund
written in c# with sql server.
use with Asp Net Web api core with EF code fisrt.
 
 
 to run the project in your computer
 change the "" to your sql server name

 there are 4 class library projects: Bll, Dal, Entity, and Dto.
 
 Entity: the data layer.
 
 Dto: Flat objects with no relationships.
 
 Dal: Functions to perform operations on the dataBase
 
 Bll :The business layer- with mapping from Entity to Dto and business logic
 
 and the main project: asp net web api-
 this project includes the controllers that perform get functions, post functions, etc.
