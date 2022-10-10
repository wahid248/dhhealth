using Core.Abstruct.Base;
using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstruct.Repositories
{
    public interface IJobPostRepository : IRepository<JobPost, int>
    {
        Task<IEnumerable<JobPostDto>> GetAllJobPosts();
        Task<JobPostDto> GetJobPostDetails(int JobId);
    }
}
