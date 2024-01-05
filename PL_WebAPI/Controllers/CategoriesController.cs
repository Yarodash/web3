using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        public ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> GetAll()
        {
            var categories = categoryService.GetAll();
            return Ok(categories.Select(c => CategoryModel.FromDTO(c)));
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryModel> Get(int id)
        {
            return Ok(CategoryModel.FromDTO(categoryService.Get(id)));
        }

        [HttpGet("filter/{partName}")]
        public ActionResult<IEnumerable<CategoryModel>> GetByPartName(string partName)
        {
            var categories = categoryService.GetCategories(partName);
            return Ok(categories.Select(c => CategoryModel.FromDTO(c)));
        }

        [HttpPost]
        public ActionResult<CategoryModel> Post([FromBody] CategoryModel category)
        {
            return Ok(categoryService.Create(category.ToDTO()));
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryModel> Put([FromBody] CategoryModel category, int id)
        {
            return Ok(categoryService.Update(id, category.ToDTO()));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}
