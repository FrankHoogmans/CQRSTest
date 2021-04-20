using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSTest.Queries.Handlers
{
    public class DeviceGetByIdRequestHandler<TResult> : IRequestHandler<DeviceGetByIdRequest<TResult>, TResult>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public DeviceGetByIdRequestHandler(
            DatabaseContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<TResult> Handle(DeviceGetByIdRequest<TResult> request, CancellationToken cancellationToken)
        {
            // Query
            var deviceQuery = this._context.Devices
                            .AsNoTracking()
                            .Where(d => d.Id == request.Id);

            // Projection
            return await this._mapper.ProjectTo<TResult>(deviceQuery)
                                        .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
