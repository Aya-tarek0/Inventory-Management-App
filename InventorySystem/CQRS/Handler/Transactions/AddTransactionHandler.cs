using AutoMapper;
using InventorySystem.CQRS.Commands.Transactions;
using InventorySystem.DTO.Transactions;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using MediatR;

namespace InventorySystem.CQRS.Handler.Transactions
{
    public class AddTransactionHandler : IRequestHandler<AddTransactionCommand, TransactionDto>

    {
        private readonly IGenericRepository<InventoryTransaction> genericRepository;
        public IMapper Mapper { get; }

        public AddTransactionHandler(IGenericRepository<InventoryTransaction> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            Mapper = mapper;
        }


        public async Task<TransactionDto> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = Mapper.Map<InventoryTransaction>(request.transactiondto);


            genericRepository.Add(transaction);
            await genericRepository.SaveChangesAsync();

            var ReturnITransaction = Mapper.Map<TransactionDto>(transaction);

            return ReturnITransaction;
        }
    }
}
