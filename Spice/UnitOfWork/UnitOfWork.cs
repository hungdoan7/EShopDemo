﻿using Spice.Data;
using Spice.Models;
using Spice.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext _context;
        private ICategoryRepository categoryRepository;
        private ISubCategoryRepository subCategoryRepository;
        private ICouponRepository couponRepository;
        private IImportHistoryRepository importHistoryRepository;
        private IApplicationUserRepository applicationUserRepository;
        private INewsRepository newsRepository;
        private IMenuItemRepository menuItemRepository;
        private IOrderHeaderRepository orderHeaderRepository;
        private IOrderDetailRepository orderDetailRepository;

        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return this.categoryRepository ?? new CategoryRepository(_context); 
            }
        }
        public ISubCategoryRepository SubCategoryRepository
        {
            get
            {
                return this.subCategoryRepository ?? new SubCategoryRepository(_context); ;
            }
        }
        public ICouponRepository CouponRepository
        {
            get
            {
                return this.couponRepository ?? new CouponRepository(_context); ;
            }
        }

        public IImportHistoryRepository ImportHistoryRepository 
        {
            get
            {
                return this.importHistoryRepository ?? new ImportHistoryRepository(_context); ;
            }
        }

        public IApplicationUserRepository ApplicationUserRepository
        {
            get
            {
                return this.applicationUserRepository ?? new ApplicationUserRepository(_context); ;
            }
        }
        public INewsRepository NewsRepository
        {
            get
            {
                return this.newsRepository ?? new NewsRepository(_context); 
            }
        }

        public IMenuItemRepository MenuItemRepository
        {
            get
            {
                return this.menuItemRepository ?? new MenuItemRepository(_context); 
            }
        }

        public IOrderHeaderRepository OrderHeaderRepository
        {
            get
            {
                return this.orderHeaderRepository ?? new OrderHeaderRepository(_context); ;
            }
        }

        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                return this.orderDetailRepository ?? new OrderDetailRepository(_context);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
