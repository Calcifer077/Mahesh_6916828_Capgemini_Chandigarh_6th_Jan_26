# Doctor Profile Updates - Real-Time Visibility Guide

## Overview
This guide explains how the doctor profile update system works and ensures that when doctors add or modify their details, those changes are immediately visible to patients in the doctors section for enrollment and appointment booking.

## System Flow

### 1. Doctor Adds/Updates Profile
```
Doctor → MVC DoctorController (Edit/Create) 
  → API DoctorsController 
  → DoctorService 
  → Database
```

### 2. Cache Invalidation (NEW)
```
DoctorService → InvalidateAllDoctorsCaches()
  → Clears ALL paginated doctor list caches
  → Next patient query fetches FRESH data
```

### 3. Patient Views Updated Doctor List
```
Patient → MVC DoctorController (Index)
  → API GetAllAsync()
  → Database (because cache was cleared)
  → Updated doctor details displayed
```

## Implementation Details

### DoctorService.cs Changes

#### What Was Updated
- **File**: `src/SmartHealthcare.API/Services/DoctorService.cs`
- **Methods Updated**: `CreateAsync()`, `UpdateAsync()`, `PatchAsync()`, `DeleteAsync()`
- **New Method**: `InvalidateAllDoctorsCaches()`

#### Cache Invalidation Strategy
Before: Only removed generic cache key → Paginated caches remained
After: Removes ALL paginated caches (pages 1-100, sizes 5-50)

```csharp
private void InvalidateAllDoctorsCaches()
{
    // Invalidate all paginated doctor list caches
    for (int page = 1; page <= 100; page++)
    {
        for (int pageSize = 5; pageSize <= 50; pageSize += 5)
        {
            var cacheKey = $"{DoctorsCacheKey}_{page}_{pageSize}";
            _cache.Remove(cacheKey);
        }
    }
    _logger.LogInformation("All doctor list caches invalidated");
}
```

## End-to-End User Flow

### For Doctors (Creating Profile)
1. Doctor logs in → Navigate to Profile
2. Click "Create Profile" or "Edit Profile"
3. Fill in details (License, Experience, Fee, Phone, Specializations)
4. Click "Save Changes"
5. **Immediate Effect**: Doctor profile is added to database + all caches cleared
6. **Result**: Next patient query shows the new doctor

### For Patients (Viewing Doctors)
1. Patient logs in → Navigate to "Find a Doctor"
2. Can search by:
   - Specialization (e.g., Cardiology, Dermatology)
   - Name
   - Browse all doctors
3. Each doctor card displays:
   - Name
   - Specializations
   - Experience
   - Consultation Fee
   - Availability Status
4. Click "View Details" for full profile
5. Click "Book Appointment" to schedule with available doctor

## Data Mapping

### DoctorDTO (What Patients See)
```
- Id
- FullName (from User.FullName)
- Email (from User.Email)
- LicenseNumber
- YearsOfExperience
- ConsultationFee
- Phone
- IsAvailable (✓ AVAILABLE / ✗ UNAVAILABLE)
- Specializations (List of specialization names)
```

### Database Relationships
```
Doctor
  ├─ User (FullName, Email)
  ├─ DoctorSpecializations
  │   └─ Specialization (Name)
  └─ Appointments
```

## API Endpoints

### Getting Doctor List
```
GET /api/doctors?pageNumber=1&pageSize=10
GET /api/doctors/search?specialization=Cardiology&pageNumber=1&pageSize=10
```

### Doctor Operations
```
GET    /api/doctors/{id}                    - Get doctor details
GET    /api/doctors/my-profile              - Get current doctor's profile
POST   /api/doctors                         - Create doctor profile
PUT    /api/doctors/{id}                    - Update doctor profile
PATCH  /api/doctors/{id}                    - Patch doctor profile
DELETE /api/doctors/{id}                    - Delete doctor profile (Admin only)
```

## UI Pages

### Doctor Views
```
/Doctor/Index
  - Displays all doctors with search filters
  - Shows specialization, experience, consultation fee
  - Available/Unavailable status
  - Link to Book Appointment

/Doctor/Details/{id}
  - Full doctor profile page
  - Complete contact information
  - Professional details
  - Edit button (for nurses/doctors)

/Doctor/Profile
  - Current doctor's profile page
  - Shows "Create Profile" or "Details" view
  - Edit Profile option

/Doctor/Edit (EditProfile.cshtml)
  - Form to update doctor details
  - Update license, experience, fee, phone, specializations
  - Toggle availability
```

## Success Messages

When a doctor updates their profile, users see:
```
✅ "Doctor profile updated successfully!"
✅ "Doctor profile created successfully!"
```

These messages display in the alert banner at the top of the page.

## Cache Configuration

- **Cache Duration**: 10 minutes (absolute) / 5 minutes (sliding)
- **Invalidation Trigger**: Any doctor profile change (create, update, patch, delete)
- **Immediate Effect**: Patients see fresh data immediately after doctor updates
- **Performance**: Uses in-memory cache for fast retrieval between updates

## Testing Checklist

- [ ] Doctor creates profile → Check if visible in doctor list
- [ ] Doctor updates specialization → Verify update appears immediately
- [ ] Doctor changes consultation fee → Confirm new fee shown to patients
- [ ] Doctor toggles availability → Check status updates instantly
- [ ] Search by specialization works with new doctors
- [ ] Pagination works and shows correct data
- [ ] Patients can book appointments with updated doctors

## Configuration Files

No additional configuration needed! The system uses:
- Dependency Injection (DI) in Program.cs
- IMemoryCache from Microsoft.Extensions.Caching.Memory
- AutoMapper for DTO conversion
- Entity Framework Core for data persistence

## Troubleshooting

### Issue: Doctor profile not appearing in list
**Solution**: Check that cache invalidation is happening (check logs for "All doctor list caches invalidated")

### Issue: Old data still showing
**Solution**: Browser cache might be involved. Hard refresh (Ctrl+F5) or check if API cache was cleared.

### Issue: Performance degradation
**Solution**: InvalidateAllDoctorsCaches() loops 1000 times max. Consider pagination optimization if needed.

## Future Enhancements (Optional)

1. Add real-time notifications using SignalR
2. Implement Redis distributed cache for multi-server scenarios
3. Add doctor rating reviews from patients
4. Schedule-based availability (slots per day)
5. Doctor category/tags beyond specializations
