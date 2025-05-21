using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerId);

            value.Title = command.Title;
            value.Description = command.Description;
            value.VideoDescription = command.VideoDescription;
            value.VideoUrl = command.VideoUrl;

            await _repository.UpdateAsync(value);

        }
    }
}
