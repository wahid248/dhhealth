using Core.Abstruct.Repositories;
using Core.Dtos;
using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class JobPostRepository : Repository<JobPost, int>, IJobPostRepository
    {
        public JobPostRepository(DataContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<JobPostDto>> GetAllJobPosts()
        {
            return await _dbSet
                .Select(jp => new JobPostDto()
                {
                    Id = jp.Id,
                    Postion = jp.Postion,
                    JobCode = jp.JobCode,
                    JobLocation = jp.JobLocation,
                    DeadLine = jp.DeadLine,
                    IsActive = jp.IsActive

                }).OrderBy(jp => jp.JobCode).ToListAsync();
        }
        public async Task<JobPostDto> GetJobPostDetails(int JobId)
        {
            return await _dbSet
                .Where(j => j.JobCode == JobId)
                .Select(jp => new JobPostDto()
                {
                    Id = jp.Id,
                    Intro = jp.Intro,
                    Postion = jp.Postion,
                    JobCode = jp.JobCode,
                    EmploymentType = jp.EmploymentType,
                    JobDescription = jp.JobDescription,
                    JobSpecification = jp.JobSpecification,
                    ApplyProcess = jp.ApplyProcess,
                    JobLocation = jp.JobLocation,
                    DeadLine = jp.DeadLine,
                    IsActive = jp.IsActive

                }).FirstOrDefaultAsync();
        }
    }
}
