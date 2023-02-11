﻿--CREATE TABLE dbo.AspNetRoleClaims (Id int IDENTITY NOT NULL, RoleId nvarchar(450) NOT NULL, ClaimType nvarchar(255) NULL, ClaimValue nvarchar(255) NULL, CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id));
--CREATE TABLE dbo.AspNetRoles (Id nvarchar(450) NOT NULL, Name nvarchar(256) NULL, NormalizedName nvarchar(256) NULL, ConcurrencyStamp nvarchar(255) NULL, CONSTRAINT PK_AspNetRoles PRIMARY KEY (Id));
--CREATE TABLE dbo.AspNetUserClaims (Id int IDENTITY NOT NULL, UserId nvarchar(450) NOT NULL, ClaimType nvarchar(255) NULL, ClaimValue nvarchar(255) NULL, CONSTRAINT PK_AspNetUserClaims PRIMARY KEY (Id));
--CREATE TABLE dbo.AspNetUserLogins (LoginProvider nvarchar(128) NOT NULL, ProviderKey nvarchar(128) NOT NULL, ProviderDisplayName nvarchar(255) NULL, UserId nvarchar(450) NOT NULL, CONSTRAINT PK_AspNetUserLogins PRIMARY KEY (LoginProvider, ProviderKey));
--CREATE TABLE dbo.AspNetUserRoles (UserId nvarchar(450) NOT NULL, RoleId nvarchar(450) NOT NULL, CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId, RoleId));
--CREATE TABLE dbo.AspNetUsers (Id nvarchar(450) NOT NULL, UserName nvarchar(256) NULL, NormalizedUserName nvarchar(256) NULL, Email nvarchar(256) NULL, NormalizedEmail nvarchar(256) NULL, EmailConfirmed bit NOT NULL, PasswordHash nvarchar(255) NULL, SecurityStamp nvarchar(255) NULL, ConcurrencyStamp nvarchar(255) NULL, PhoneNumber nvarchar(255) NULL, PhoneNumberConfirmed bit NOT NULL, TwoFactorEnabled bit NOT NULL, LockoutEnd datetimeoffset(7) NULL, LockoutEnabled bit NOT NULL, AccessFailedCount int NOT NULL, CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id));
--CREATE TABLE dbo.AspNetUserTokens (UserId nvarchar(450) NOT NULL, LoginProvider nvarchar(128) NOT NULL, Name nvarchar(128) NOT NULL, Value nvarchar(255) NULL, CONSTRAINT PK_AspNetUserTokens PRIMARY KEY (UserId, LoginProvider, Name));
CREATE TABLE Category (category_id int IDENTITY NOT NULL, name nvarchar(255) NOT NULL, PRIMARY KEY (category_id));