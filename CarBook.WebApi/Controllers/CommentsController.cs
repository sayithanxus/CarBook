﻿
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Repositories.CommentRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }

        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var values = _commentRepository.GetCommentsByBlogId(id);
            return Ok(values);
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentRepository.GetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment command)
        {
            _commentRepository.Create(command);
            return Ok("Yorum Eklendi");
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            _commentRepository.Remove(id);
            return Ok("Yorum Silindi");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment command)
        {
            _commentRepository.Update(command);
            return Ok("Yorum Güncellendi");
        }
        [HttpGet("CommentCountByBlog")]
        public IActionResult CommentCountByBlog(int id)
        {
            var value = _commentRepository.GetCountCommentByBlog(id);
            return Ok(value);
        }

        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum başarıyla eklendi");
        }
    }
}
