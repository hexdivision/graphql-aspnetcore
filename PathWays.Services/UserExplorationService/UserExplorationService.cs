using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PathWays.Common.Utilities;
using PathWays.Data.Model;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.UserExplorationService
{
    public class UserExplorationService : IUserExplorationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserExplorationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserExploration> CreateUserExploration(UserExploration userExploration)
        {
            userExploration.AccessCode = await GenereateAccessCode();
            userExploration.IsDeleted = false;
            userExploration.ExplorationStatus = (byte)ExplorationStatus.InProgress;

            var result = await _unitOfWork.UserExplorationRepository.InsertAsync(userExploration);
            await _unitOfWork.Complete();

            return result;
        }

        public async Task<bool> DeleteUserExploration(int explorationId)
        {
            var exploration = await _unitOfWork.UserExplorationRepository.GetByIdAsync(explorationId);
            if (exploration != null)
            {
                exploration.IsDeleted = true;
                _unitOfWork.UserExplorationRepository.Attach(exploration);
                var result = await _unitOfWork.Complete();

                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<UserExploration> GetUserExploration(int explorationId)
        {
            var result = await _unitOfWork.UserExplorationRepository.GetByIdAsync(explorationId);
            return result;
        }

        public async Task<UserExploration> GetNoTrackingUserExploration(int explorationId)
        {
            var result = await _unitOfWork.UserExplorationRepository.GetNoTrackingByIdAsync(x => x.UserExplorationId == explorationId);
            return result;
        }

        public async Task<UserExploration> GetUserExploration(string accessCode)
        {
            var result = await _unitOfWork.UserExplorationRepository.GetByAccessCode(accessCode);
            return result;
        }

        public async Task<ICollection<UserExploration>> GetUserExplorations()
        {
            var result = await _unitOfWork.UserExplorationRepository.GetAllAsync();
            return result;
        }

        public async Task<UserExploration> UpdateUserExploration(UserExploration userExploration)
        {
            _unitOfWork.UserExplorationRepository.Attach(userExploration);
            var result = await _unitOfWork.Complete();

            if (result == 1)
            {
                return userExploration;
            }

            return null;
        }

        private async Task<string> GenereateAccessCode()
        {
            var badWords = _unitOfWork.ExcludeWordRepository.GetAllWords();
            var evidenceCode = await GetAccessCode(Constants.AccessCodeLenght);
            return evidenceCode;
        }

        private async Task<string> GetAccessCode(int length)
        {
            const string Symbols = "234679ACDEFGHJKLMNPQRTUVWXTabcdefhikmnprstuvwxyz";
            StringBuilder builder = new StringBuilder();
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    builder.Append(Symbols[(int)(num % (uint)Symbols.Length)]);
                }
            }

            var words = _unitOfWork.ExcludeWordRepository.GetAllWords().ToList();
            var evidenceCode = builder.ToString();
            var firstLetter = evidenceCode.FirstOrDefault();

            var accessCodes = await _unitOfWork.UserExplorationRepository.GetAccessCodes(firstLetter);
            if (accessCodes.Contains(evidenceCode))
            {
                await GetAccessCode(Constants.AccessCodeLenght);
            }

            if (words.Any(evidenceCode.ToLower().Contains))
            {
                await GetAccessCode(Constants.AccessCodeLenght);
            }

            return evidenceCode;
        }
    }
}
