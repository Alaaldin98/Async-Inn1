﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Models.Interfaces;
using HotelManagement.Models.DTO;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _room.GetRooms();
            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            RoomDTO room = await _room.GetRoom(id);
            return Ok(room);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            var modifiedRoom = await _room.UpdateRoom(id, room);

            return Ok(modifiedRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(RoomDTO room)
        {
            RoomDTO newRoom = await _room.Create(room);
            return Ok(newRoom);
        }
        [HttpPost("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> PostRoomAminity(int RoomId, int AmenityId)
        {
            await _room.AddAmenityToRoom(RoomId, AmenityId);
            return NoContent();
        }
        // DELETE: api/Rooms/5
        [HttpDelete("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> DeleteRoomAminity(int roomId, int amenityId)
            {
            await _room.RemoveAmentityFromRoom(roomId, amenityId);
            return NoContent();
        }

        
    }
}
