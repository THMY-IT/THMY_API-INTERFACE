# Management Interface Design Plan

## Overview
This plan outlines the development of a comprehensive management interface for all entities in the Contracts project. The interface will be modular, minimal, and professional.

## Entities to Manage

### Core Entities (from THMY_API.Models)
1. **Role** - User roles (roleId, roleName, roleDescription)
2. **Permission** - System permissions (permissionId, permissionName, permissionDescription, systemId)
3. **EmpRole** - Employee-Role associations (empId, roleId, systemId)
4. **RolePermission** - Role-Permission associations (roleId, permissionId, systemId)
5. **APIStorage** - API key storage (Id, applicationName, apiSecret)

### Reference Entities (Read-Only)
- **Employee** - Employee data from InternalSystem DLL (read-only, for reference when assigning roles)
- **User** - Login helper class (not managed in interface, used for authentication only)

## Phase 1: Backend Controllers (THMY-API)

### 1.1 Existing Controllers (No Changes)
- **UserController** ✅ (Keep as-is for login functionality only)
  - Login endpoint for authentication
  - GetAllUsers endpoint for viewing employees (read-only reference)

### 1.2 Create New Controllers
- **RoleController** - CRUD operations for Role entity
  - GET /Role/all
  - GET /Role/{id}
  - POST /Role
  - PUT /Role/{id}
  - DELETE /Role/{id}

- **PermissionController** - CRUD operations for Permission entity
  - GET /Permission/all
  - GET /Permission/{id}
  - GET /Permission/system/{systemId}
  - POST /Permission
  - PUT /Permission/{id}
  - DELETE /Permission/{id}

- **EmpRoleController** - Manage employee-role associations
  - GET /EmpRole/all
  - GET /EmpRole/employee/{empId}
  - POST /EmpRole
  - DELETE /EmpRole (remove association)

- **RolePermissionController** - Manage role-permission associations
  - GET /RolePermission/all
  - GET /RolePermission/role/{roleId}
  - POST /RolePermission
  - DELETE /RolePermission (remove association)

- **APIStorageController** - Manage API keys
  - GET /APIStorage/all
  - GET /APIStorage/{id}
  - POST /APIStorage
  - PUT /APIStorage/{id}
  - DELETE /APIStorage/{id}

## Phase 2: Modular Frontend API Controllers (API_Interface)

### 2.1 Refactor APIRequestController
Split into separate controller classes per entity:
- **EmployeeApiController** - Employee read-only API calls (from UserController)
- **RoleApiController** - Role-related API calls
- **PermissionApiController** - Permission-related API calls
- **EmpRoleApiController** - EmpRole-related API calls
- **RolePermissionApiController** - RolePermission-related API calls
- **APIStorageApiController** - APIStorage-related API calls

### 2.2 Base Configuration
- Create a base class or shared service for RestClient configuration
- Centralize API endpoint configuration
- Handle authentication headers consistently

## Phase 3: Management Interface Pages

### 3.1 Navigation Structure
- Main layout with sidebar navigation
- Tab-based or page-based navigation for each entity

### 3.2 Pages to Create

#### 3.2.1 Dashboard/Home Page
- Overview of all entities
- Quick stats (counts per entity)
- Recent activity

#### 3.2.2 Employee Reference Page (Read-Only)
- List all employees from InternalSystem
- View employee details (read-only)
- Search/filter functionality
- Reference for assigning roles in EmpRole management

#### 3.2.3 Role Management Page
- List all roles
- Create/Edit/Delete roles
- View role details (name, description)
- Link to role permissions

#### 3.2.4 Permission Management Page
- List all permissions
- Filter by systemId
- Create/Edit/Delete permissions
- View permission details

#### 3.2.5 Employee-Role Assignment Page
- List all employee-role associations
- Assign roles to employees (select from Employee reference)
- Remove role assignments
- Filter by employee or role
- Dropdown/autocomplete for employee selection (from Employee reference data)

#### 3.2.6 Role-Permission Assignment Page
- List all role-permission associations
- Assign permissions to roles
- Remove permission assignments
- Filter by role or permission

#### 3.2.7 API Storage Management Page
- List all API keys
- Create/Edit/Delete API keys
- Secure display (masked secrets)
- View application details

## Phase 4: UI/UX Design Principles

### 4.1 Minimal Design
- Clean, uncluttered interface
- White space for readability
- Simple color scheme (max 2-3 colors)
- Bootstrap CSS classes for consistency

### 4.2 Professional Appearance
- Consistent typography
- Professional table layouts
- Clear action buttons
- Loading states and error handling
- Success/error notifications

### 4.3 Components to Create
- **DataTable Component** - Reusable table with sorting/pagination
- **FormModal Component** - Reusable modal for create/edit forms
- **DeleteConfirm Component** - Confirmation dialog for deletions
- **NotificationToast Component** - Success/error messages

## Phase 5: Implementation Order

### Step 1: Backend Controllers
1. Create all missing controllers in THMY-API
2. Implement CRUD operations
3. Test endpoints

### Step 2: Frontend API Layer
1. Refactor APIRequestController into modular controllers
2. Implement all API methods
3. Test API connectivity

### Step 3: UI Components
1. Create reusable components
2. Set up navigation structure
3. Create base layout

### Step 4: Management Pages
1. Create pages for each entity
2. Implement CRUD operations
3. Add search/filter functionality

### Step 5: Polish
1. Error handling
2. Loading states
3. User feedback
4. Testing

## Technical Considerations

### API Endpoints Convention
- Base URL: `http://localhost:5162`
- Headers: Application-Name, API-Key, Content-Type
- Response format: JSON

### Error Handling
- Try-catch blocks in all API calls
- User-friendly error messages
- Logging for debugging

### Security
- Mask sensitive data (API secrets in APIStorage)
- Validation on forms
- Confirm destructive actions

---

**Next Steps:** Review and approve this plan before proceeding with implementation. Each phase can be implemented and tested independently.

