﻿using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
	public class UpdateFooterAdressCommandHandler : IRequestHandler<UpdateFooterAdressCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public UpdateFooterAdressCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.FooterAddressID);
			values.Phone = request.Phone;
			values.Address = request.Address;
			values.Description = request.Description;
			values.Email = request.Email;
			await _repository.UpdateAsync(values);
		}
	}
}
