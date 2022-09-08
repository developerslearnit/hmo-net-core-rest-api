using AvonHMO.Domain.Interfaces;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Domain.Interfaces.Toshfa;
using AvonHMO.Domain.Services.Avon;
using AvonHMO.Domain.Services.Toshfa;
using AvonHMO.Persistence.StorageContexts.Avon;
using AvonHMO.Persistence.StorageContexts.Toshfa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Domain.Services
{
    public class RepositoryManager : IRepositoryManager
    {

        private ToshfaDbContext _context;
        private AvonDbContext _avonContext;
        private IToshfaRepository _toshfaRepository;
        private IAuthenticationRepository _avonAuthRepository;
        private IAvonRepository _avonRepository;
        private  IDbConnection _connection;
        private ISettings _settings;
        private IPostRepository _postRepository;
        private IPlanRepository _planRepository;
        private IEnrolleeRepository _enrolleeRepository;
        public RepositoryManager(ToshfaDbContext context, 
            AvonDbContext avonContext,
            IDbConnection connection)
        {
            _context = context;
            _avonContext = avonContext;
            _connection = connection;
        }

        public IToshfaRepository Toshfa
        {
            get {

                if (_toshfaRepository == null)
                    _toshfaRepository = new ToshfaRepository(_context, _connection);

                return _toshfaRepository;
            }
        }

        public IAuthenticationRepository AvonAuth
        {
            get
            {
                if (_avonAuthRepository == null)
                    _avonAuthRepository = new AuthenticationRepository(_avonContext);
                return _avonAuthRepository;
            }
        }
        
        public IAvonRepository Avon
        {
            get
            {
                if (_avonRepository == null)
                    _avonRepository = new AvonRepository(_avonContext);
                return _avonRepository;
            }
        }

        public ISettings Settings
        {
            get
            {
                if (_settings == null)
                    _settings = new Settings(_avonContext);
                return _settings;
            }
        }

        public IPostRepository Posts
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(_avonContext);
                return _postRepository;
            }
        }

        public IPlanRepository Plans
        {
            get
            {
                if (_planRepository == null)
                    _planRepository = new PlanRepository(_avonContext);
                return _planRepository;
            }
        }

        public IEnrolleeRepository Enrollee
        {
            get
            {
                if(_enrolleeRepository==null)
                    _enrolleeRepository = new EnrolleeRepository(_avonContext, _context, _connection);

                return _enrolleeRepository;
            }
        }
    }
}
