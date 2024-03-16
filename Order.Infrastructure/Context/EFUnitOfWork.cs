﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Context
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IMediator _mediator;

        public EFUnitOfWork(DbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<bool> Commit()
        {
            // Öncelikle, DbContext üzerinden tüm değişiklikleri kaydet
            await _dbContext.SaveChangesAsync();

            // Sonra, toplanan tüm domain eventleri al ve yayınla
            var entitiesWithEvents = _dbContext.ChangeTracker
                .Entries<Entity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents != null && e.DomainEvents.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.DomainEvents.ToArray();
                entity.ClearDomainEvents();

                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent);
                }
            }

            return true;
        }
    }

}