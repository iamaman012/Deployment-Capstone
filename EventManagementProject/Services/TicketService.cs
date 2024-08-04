using EventManagementProject.DTOs.TicketDTO;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace EventManagementProject.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IScheduledPublicEventRepository _scheduledPublicEventRepository;
        private readonly EmailService _emailService;
        private readonly IUserRepository _userRepository;

        public TicketService(ITicketRepository ticketRepository,IScheduledPublicEventRepository scheduledPublicEventRepository, EmailService emailService,IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _scheduledPublicEventRepository = scheduledPublicEventRepository;
            _emailService = emailService;
            _userRepository = userRepository;
        }
        public async Task AddTicket(AddTicketDTO ticketDTO)
        {
            try
            {
                var ticket = new Ticket
                {
                    ScheduledPublicEventId = ticketDTO.ScheduledPublicEventId,
                    UserId = ticketDTO.UserId,
                    NumberOfSeats = ticketDTO.NumberOfSeats,
                    Amount = ticketDTO.Amount,
                    PurchaseDate = DateTime.Now,
                    Status = "Active"
                };
                await _ticketRepository.AddTicket(ticket);
                await _scheduledPublicEventRepository.UpdateRemainigSeats(ticketDTO.ScheduledPublicEventId, ticketDTO.NumberOfSeats);
                var scheduledPublicEvent = await _scheduledPublicEventRepository.GetScheduledPublicEventById(ticketDTO.ScheduledPublicEventId);
                var user = await _userRepository.GetById(ticketDTO.UserId);
                var userName = user.FullName;
                var eventName = scheduledPublicEvent.UserEventName;
                var eventDate = scheduledPublicEvent.PublicQuotationRequest.StartDate;
                var eventTiming = scheduledPublicEvent.PublicQuotationRequest.Timing;
                var location = scheduledPublicEvent.PublicQuotationRequest.LocationDetails;
                var city = scheduledPublicEvent.PublicQuotationRequest.City;
                var email = user.Email;
                string subject = "Ticket Purchase Confirmation";
                string body = $"Dear {userName},\n\n" +
                $"Thank you for purchasing a ticket for the event '{eventName}'.\n\n" +
                $"Ticket ID: {ticket.TicketId}\n" +
                $"Event Date: {eventDate.ToString("dd MMM yyyy")}\n" +
                $"Event Timing: {eventTiming}\n" +
                $"Event Location: {location}\n" +
                $"City: {city}\n\n" +
                $"Number of Seats: {ticketDTO.NumberOfSeats}\n" +
                $"Total Amount: {ticketDTO.Amount}\n\n" +
                $"We look forward to seeing you there!\n\n" +
                "Best regards,\nEvent Management Team";


                _emailService.SendEmail(email, subject, body);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReturnTicketDTO>> GetTicketByUserId(int userId)
        {
            try
            {
                var tickets = await _ticketRepository.GetTicketByuserid(userId);
                var returnTickets = tickets.Select(ticket => new ReturnTicketDTO
                {
                    TicketId = ticket.TicketId,
                    
                    UserEventName = ticket.ScheduledPublicEvent.UserEventName,
                    StartDate = ticket.ScheduledPublicEvent.PublicQuotationRequest.StartDate,
                    EventTiming = ticket.ScheduledPublicEvent.PublicQuotationRequest.Timing,
                    Location = ticket.ScheduledPublicEvent.PublicQuotationRequest.LocationDetails,
                    City = ticket.ScheduledPublicEvent.PublicQuotationRequest.City,
                    TotalSeats = ticket.NumberOfSeats,
                    TotalAmount = ticket.Amount,
                    PurchaseDate = ticket.PurchaseDate.ToString("dd MMM yyyy"),

                });
                return returnTickets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
