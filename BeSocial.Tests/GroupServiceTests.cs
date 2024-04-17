using BeSocial.Services.Group;
using BeSocial.Services.Interfaces;
using BeSocial.Tests.UnitTests;
using BeSocial.Web.ViewModels.Enums;
using BeSocial.Web.ViewModels.Group;
using BeSocial.Web.ViewModels.Post;
using BeSocial.Web.ViewModels.Premium;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Tests
{
    [TestFixture]
    public class GroupServiceTests : UnitTestsBase
    {
        private IGroupService groupService;

        [OneTimeSetUp]
        public void SetUp()
            => groupService = new GroupService(context);


        [Test]
        public async Task AllCategoriesAsync_ShouldReturnCorrectResult()
        {
            // Act
            var result = await groupService.AllCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<GroupCategoryServiceModel>>(result);
            Assert.That(Categories.Count, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task AllCategoriesNamesAsync_ShouldReturnCorrectResult()
        {
            // Act
            var result = await groupService.AllCategoriesNamesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<string>>(result);
            Assert.That(Categories.Count, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task CategoryExistAsync_ShouldReturnTrueIfCategoryExists()
        {
            // Act
            var exists = await groupService.CategoryExistAsync(1);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CreateGroupAsync_ShouldCreateGroup()
        {
            // Arrange
            var groupFormModel = new GroupFormModel
            {
                Name = Group.Name,
                CategoryId = Group.CategoryId
            };
            var userId = PremiumUser.ApplicationUserId.ToString();

            // Act
            await groupService.CreateGroupAsync(groupFormModel, userId);

            // Assert
            var createdGroup = await context.Groups.FirstOrDefaultAsync(g => g.Id == Group.Id);
            Assert.IsNotNull(createdGroup);
            Assert.That(Group.Name, Is.EqualTo(createdGroup.Name));
            Assert.That(Group.CategoryId, Is.EqualTo(createdGroup.CategoryId));
        }

        [Test]
        public async Task EditGroupAsync_ShouldEditGroup()
        {
            // Arrange
            var groupId = Group.Id.ToString();
            var groupFormModel = new GroupFormModel
            {
                Name = Group.Name,
                CategoryId = Group.CategoryId
            };

            // Act
            await groupService.EditGroupAsync(groupFormModel, groupId);

            // Assert
            var editedGroup = await context.Groups.FirstOrDefaultAsync(g => g.Id == Guid.Parse(groupId));
            Assert.IsNotNull(editedGroup);
            Assert.That(Group.Name, Is.EqualTo(editedGroup.Name));
            Assert.That(Group.CategoryId, Is.EqualTo(editedGroup.CategoryId));
        }

        [Test]
        public async Task GetAllJoinedGroupsAsync_ShouldReturnCorrectGroups()
        {
            // Arrange
            var userId = NormalUser.Id.ToString();

            // Act
            var result = await groupService.GetAllJoinedGroupsAsync(userId);

            var joinedGroups = await context.GroupParticipants.Where(x => x.ParticipantId.ToString() == userId).CountAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<GroupAllViewModel>>(result);
            Assert.That(joinedGroups, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task GetAllMyGroupsAsync_ShouldReturnCorrectGroups()
        {
            // Arrange
            var userId = PremiumUser.ApplicationUserId.ToString();

            // Act
            var result = await groupService.GetAllMyGroupsAsync(userId);

            var myGroups = await context.Groups.Where(x => x.CreatorId == PremiumUser.Id).CountAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<GroupAllViewModel>>(result);
            Assert.That(myGroups, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task GetAllPostsForGroupByGroupIdAsync_ShouldReturnCorrectPosts()
        {
            // Arrange
            var groupId = Group.Id.ToString();

            // Act
            var result = await groupService.GetAllPostsForGroupByGroupIdAsync(groupId);

            var postsFromGroup = await context.Posts.Where(x => x.GroupId.ToString() == groupId).CountAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<PostAllViewModel>>(result);
            Assert.That(postsFromGroup, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task GetGroupDeleteModelByIdAsync_ShouldReturnCorrectModel()
        {
            // Arrange
            var groupId = Group.Id.ToString();

            // Act
            var result = await groupService.GetGroupDeleteModelByIdAsync(groupId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<GroupDeleteViewModel>(result);
            Assert.That(groupId, Is.EqualTo(result.Id));
        }

        [Test]
        public async Task GetGroupFormModelByIdAsync_ShouldReturnCorrectModel()
        {
            // Arrange
            var groupId = Group.Id.ToString();

            // Act
            var result = await groupService.GetGroupFormModelByIdAsync(groupId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<GroupFormModel>(result);
            Assert.That(Group.Name, Is.EqualTo(result.Name));
        }

        [Test]
        public async Task GroupExistAsync_ShouldReturnTrueIfGroupExists()
        {
            // Arrange
            var groupId = Group.Id.ToString();

            // Act
            var exists = await groupService.GroupExistAsync(groupId);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task HasUserWithIdAsync_ShouldReturnCorrectResult()
        {
            // Arrange
            var groupId = Group.Id.ToString();
            var userId = PremiumUser.ApplicationUserId.ToString();

            // Act
            var result = await groupService.HasUserWithIdAsync(groupId, userId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task JoinGroupAsync_ShouldAddUserToGroup()
        {
            // Arrange
            var groupId = Group.Id.ToString();
            var userId = PremiumUser.ApplicationUserId.ToString();

            var groupParticipantsCountBefore = await context.GroupParticipants.CountAsync();
            // Act
            await groupService.JoinGroupAsync(groupId, userId);

            var groupParticipantsCountAfter = await context.GroupParticipants.CountAsync();

            // Assert
            var groupParticipant = await context.GroupParticipants
                .FirstOrDefaultAsync(gp => gp.GroupId == Guid.Parse(groupId) && gp.ParticipantId == Guid.Parse(userId));
            Assert.IsNotNull(groupParticipant);
            Assert.That(groupParticipantsCountAfter, Is.EqualTo(groupParticipantsCountBefore + 1));
        }

        [Test]
        public async Task IsUserPremiumAsync_ShouldReturnCorrectResult()
        {
            // Arrange
            var userId = PremiumUser.ApplicationUserId.ToString();

            // Act
            var result = await groupService.IsUserPremiumAsync(userId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetPremiumUserByPremiumIdAsync_ShouldReturnCorrectUser()
        {
            // Arrange
            var creatorId = PremiumUser.Id;

            // Act
            var result = await groupService.GetPremiumUserByPremiumIdAsync(creatorId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<PremiumUserAccountViewModel>(result);
            Assert.That(PremiumUser.FirstName, Is.EqualTo(result.FirstName));
        }


        [Test]
        public async Task AddPostToGroupAsync_ShouldCreateNewPostInGroup()
        {
            // Arrange
            var model = new PostFormServiceModel
            {
                Title = Post.Title,
                Description = Post.Description,
                CategoryId = Post.CategoryId 
            };
            string userId = PremiumUser.ApplicationUserId.ToString();
            string groupId = Group.Id.ToString();
            int expectedPostsCountBefore = await context.Posts.Where(x => x.GroupId.ToString() == groupId).CountAsync();

            // Act
            await groupService.AddPostToGroupAsync(model, groupId, userId);

            int expectedPostsCountAfter = await context.Posts.Where(x => x.GroupId.ToString() == groupId).CountAsync();

            // Assert
            Assert.That(expectedPostsCountAfter, Is.EqualTo(expectedPostsCountBefore + 1));
        }


        [Test]
        public async Task GetAllGroupsAsync_ShouldReturnCorrectPosts()
        {
            // Arrange
            string category = "Sport";
            string searchTerm = "champions";
            int currentPage = 1;
            int groupsPerPage = 3;
            int expectedTotalGroupsCount = await context.Groups
                .Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).CountAsync();

            // Act
            var result = await groupService.GetAllGroupsAsync(category, searchTerm, GroupSorting.MostJoined, currentPage, groupsPerPage);

            // Assert
            Assert.That(expectedTotalGroupsCount, Is.EqualTo(result.TotalGroupsCount));
        }
    }
}
