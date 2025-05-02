using AutoMapper;
using InventorySystem.CQRS.Commands.Transactions;
using InventorySystem.DTO.Transactions;
using InventorySystem.Interfaces;
using InventorySystem.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.CQRS.Handler.Transactions
{
    public class TransferTransactionHandler : IRequestHandler<TransferTransactionCommand,AddTransferTransactionDTO>
    {
        private readonly IGenericRepository<InventoryTransaction> genericRepository;
        public IMapper Mapper { get; }

        public TransferTransactionHandler(IGenericRepository<InventoryTransaction> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            Mapper = mapper;
        }
        public async Task<AddTransferTransactionDTO> Handle(TransferTransactionCommand request, CancellationToken cancellationToken)
        {


          
            var transaction = Mapper.Map<InventoryTransaction>(request.AddTransferTransactionDTO);


            genericRepository.Add(transaction);
            await genericRepository.SaveChangesAsync();
            var transactionSaved = await genericRepository.Get(e => e.Id == transaction.Id).FirstOrDefaultAsync();
            if (transactionSaved == null)
            {
                throw new Exception("Transaction was not saved.");
            }
            var ReturnITransaction = Mapper.Map<AddTransferTransactionDTO>(transaction);

            return ReturnITransaction;
       
    }
}
    
}
