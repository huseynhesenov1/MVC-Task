using AutoMapper;
using LogisticaProject.BL.DTOs;
using LogisticaProject.BL.Services.Abstractions;
using LogisticaProject.Core.Entities;
using LogisticaProject.DAL.Contexts;
using LogisticaProject.DAL.Repostories.Abstractions;
using LogisticaProject.DAL.Repostories.Implementations;



namespace LogisticaProject.BL.Services.Implementations
{
	public class TransportService : ITransportService
	{
		private readonly ITransportRepostory _transportRepostory;
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		//private readonly IWebHostEnvironment _webHostEnvironment;

		public TransportService(ITransportRepostory transportRepostory, AppDbContext context, IMapper mapper)
		{
			_transportRepostory = transportRepostory;
			_context = context;
			_mapper = mapper;
		}

		public async Task<Transport> CreateAsync(TransportDto transportDto)
		{

			

			var folderName = Path.Combine("wwwroot", "ImageUpload");
			var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
			if (!Directory.Exists(pathToSave))
			{
				Directory.CreateDirectory(pathToSave);
			}

			var fileName = transportDto.Image.FileName;


			if (File.Exists(Path.Combine(pathToSave, fileName)))
			{
				fileName = Path.GetFileNameWithoutExtension(fileName) + Guid.NewGuid().ToString() + Path.GetExtension(fileName);
            }

            var fullPath = Path.Combine(pathToSave, fileName);

			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				transportDto.Image.CopyTo(stream);
			}



			Transport transport = _mapper.Map<Transport>(transportDto);
			transport.ImgPath = fileName;
			var res = await _transportRepostory.CreateAsync(transport);
			await _context.SaveChangesAsync();
			return res;
		}

		public async Task<List<Transport>> GetAllAsync()
		{
			return await _transportRepostory.GetAllAsync();
		}

		public async Task<Transport> GetByIdAsync(int id)
		{
			return await _transportRepostory.GetByIdForUpdateAsync(id);
		}

		public async Task<Transport> SoftDeleteAsync(int id)
		{
			Transport transport = await _transportRepostory.GetByIdAsync(id);
			if (transport == null)
			{
				throw new Exception("Something went wrong");
			}
			var res = _transportRepostory.SoftDelete(transport);
			await _context.SaveChangesAsync();
			return res;
		}

		public async Task<Transport> UpdateAsync(int id, TransportDto transportDto)
		{
			Transport transport = await _transportRepostory.GetByIdForUpdateAsync(id);
			if (transport == null)
			{
				throw new Exception("Something went wrong");
			}
			Transport updateTransport = _mapper.Map<Transport>(transportDto);
			updateTransport.UpdateAt = DateTime.Now;
			updateTransport.CreateAt = transport.CreateAt;
			updateTransport.Id = transport.Id;
			var res = _transportRepostory.Update(updateTransport);
			await _context.SaveChangesAsync();
			return res;
		}


	}
}
