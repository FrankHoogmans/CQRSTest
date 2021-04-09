using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSTest.Queries.Handlers
{
    public class DeviceGetByIdHandler<TResult> : IRequestHandler<DeviceGetByIdRequest<TResult>, TResult>
    {
        private readonly DatabaseContext _context;

        public DeviceGetByIdHandler(DatabaseContext context)
        {
            this._context = context;
        }

        public async Task<TResult> Handle(DeviceGetByIdRequest<TResult> request, CancellationToken cancellationToken)
        {
            return await this._context.Devices
                            .AsNoTracking()
                            .Where(d => d.Id == request.Id)
                            .ProjectTo<TResult>(request.Mapping)
                            .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
