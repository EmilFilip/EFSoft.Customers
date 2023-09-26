global using System.Diagnostics.CodeAnalysis;

global using EFSoft.Customers.Api.Configuration;
global using EFSoft.Customers.Api.Endpoints;
global using EFSoft.Customers.Application.Commands.CreateCustomer;
global using EFSoft.Customers.Application.Commands.DeleteCustomer;
global using EFSoft.Customers.Application.Commands.UpdateCustomer;
global using EFSoft.Customers.Application.Queries.GetCustomer;
global using EFSoft.Customers.Application.Queries.GetCustomers;
global using EFSoft.Customers.Domain.Models;
global using EFSoft.Customers.Domain.RepositoryContracts;
global using EFSoft.Customers.Infrastructure.DBContexts;
global using EFSoft.Customers.Infrastructure.Repositories;
global using EFSoft.Shared.Cqrs.Configuration;

global using MediatR;

global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
