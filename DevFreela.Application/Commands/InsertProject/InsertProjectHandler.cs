﻿using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertProject {
    public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>> 
    {
        private readonly DevFreelaDbContext _context;
        public InsertProjectHandler(DevFreelaDbContext context) 
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken) 
        {
            var project = request.ToEntity();

            await _context.Projects.AddAsync(project);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(project.Id);
        }
    }
}
