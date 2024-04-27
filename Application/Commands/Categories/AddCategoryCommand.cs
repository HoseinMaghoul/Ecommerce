using Application.Results;
using Application.Failures;
using MediatR;
using OneOf;
using Application.Results.Category;
using Domain.Entities;

namespace Application.Commands.Categories;



public record AddCategoryCommand(string Name, string Slug, int? ParentId) : IRequest<OneOf<AddCategoryResult, CategoryFailure>>;