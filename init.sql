DROP TABLE IF EXISTS Materials CASCADE;
DROP TABLE IF EXISTS Motors CASCADE;
DROP TABLE IF EXISTS Pumps CASCADE;

CREATE TABLE Materials
(
    Id          UUID PRIMARY KEY,
    Name        VARCHAR(255) NOT NULL,
    Description TEXT
);

CREATE TABLE Motors
(
    Id           UUID PRIMARY KEY,
    Name         VARCHAR(255)   NOT NULL,
    Power        DECIMAL(10, 2) NOT NULL,
    Current      DECIMAL(10, 2) NOT NULL,
    NominalSpeed INT            NOT NULL,
    Price        DECIMAL(10, 2) NOT NULL,
    Description  TEXT
);

CREATE TABLE Pumps
(
    Id                UUID PRIMARY KEY,
    Name              VARCHAR(255)   NOT NULL,
    MaxPressure       DECIMAL(10, 2) NOT NULL,
    LiquidTemperature DECIMAL(10, 2) NOT NULL,
    Weight            DECIMAL(10, 2) NOT NULL,
    ImageName         varchar(255)   NOT NULL,
    Image             bytea,
    Price             DECIMAL(10, 2) NOT NULL,
    MotorId           UUID REFERENCES Motors (Id),
    FrameMaterialId   UUID REFERENCES Materials (Id),
    WheelMaterialId   UUID REFERENCES Materials (Id),
    Description       TEXT
);

-- Добавление данных в таблицу Materials
INSERT INTO Materials (Id, Name, Description)
VALUES ('6ecd8c99-4036-403d-bf84-cf8400f67836', 'Stainless Steel', 'High-strength, durable steel material.'),
       ('7ecd8c99-4036-403d-bf84-cf8400f67836', 'Copper', 'Versatile metal with various uses.'),
       ('9ecd8c99-4036-403d-bf84-cf8400f67836', 'Titanium',
        'Lightweight, strong, and durable metal with excellent corrosion resistance.'),
       ('0ecd8c99-4036-403d-bf84-cf8400f67836', 'Nickel',
        'Versatile metal used in a variety of applications due to its resistance to corrosion.'),
       ('8ecd8c99-4036-403d-bf84-cf8400f67836', 'Aluminum', 'Lightweight, strong, and durable metal.');

-- Добавление данных в таблицу Motors
INSERT INTO Motors (Id, Name, Power, Current, NominalSpeed, Price, Description)
VALUES ('6ecd8c99-4036-403d-bf84-cf8400f67837', 'Motor A', 1.5, 3.0, 1500, 1000.00,
        'High-efficiency motor for heavy-duty applications.'),
       ('7ecd8c99-4036-403d-bf84-cf8400f67837', 'Motor B', 2.0, 4.0, 2000, 1500.00,
        'Moderate-efficiency motor for medium loads.'),
       ('8ecd8c99-4036-403d-bf84-cf8400f67837', 'Motor C', 0.75, 1.5, 1000, 500.00,
        'Low-efficiency motor for light-duty applications.'),
       ('9ecd8c99-4036-403d-bf84-cf8400f67837', 'Motor D', 3.0, 5.0, 2500, 2000.00,
        'Very high-efficiency motor for very heavy-duty applications.'),
       ('0ecd8c99-4036-403d-bf84-cf8400f67837', 'Motor E', 1.0, 2.0, 1000, 750.00,
        'Low-efficiency motor for light-duty applications with low power requirements.');

-- Добавление данных в таблицу Pumps
INSERT INTO Pumps (Id, Name, MaxPressure, LiquidTemperature, Weight, ImageName, Image, Price, MotorId, FrameMaterialId,
                   WheelMaterialId, Description)
VALUES ('6ecd8c99-4036-403d-bf84-cf8400f67838', 'Pump 1', 100.0, 10.0, 50.0, 'a.jpg', 'image_data', 5000.00,
        '6ecd8c99-4036-403d-bf84-cf8400f67837', '6ecd8c99-4036-403d-bf84-cf8400f67836',
        '7ecd8c99-4036-403d-bf84-cf8400f67836', 'High-pressure pump with stainless steel frame and copper wheels.'),
       ('7ecd8c99-4036-403d-bf84-cf8400f67838', 'Pump 2', 150.0, 20.0, 75.0, 'b.jpg', 'image_data', 7000.00,
        '7ecd8c99-4036-403d-bf84-cf8400f67837', '7ecd8c99-4036-403d-bf84-cf8400f67836',
        '8ecd8c99-4036-403d-bf84-cf8400f67836', 'Medium-pressure pump with copper frame and aluminum wheels.'),
       ('8ecd8c99-4036-403d-bf84-cf8400f67838', 'Pump 3', 50.0, 5.0, 25.0, 'c.jpg', 'image_data', 3000.00,
        '8ecd8c99-4036-403d-bf84-cf8400f67837', '8ecd8c99-4036-403d-bf84-cf8400f67836',
        '6ecd8c99-4036-403d-bf84-cf8400f67836', 'Low-pressure pump with aluminum frame and stainless steel wheels.'),
       ('9ecd8c99-4036-403d-bf84-cf8400f67838', 'Pump 4', 120.0, 15.0, 60.0, 'd.jpg', 'image_data', 6000.00,
        '9ecd8c99-4036-403d-bf84-cf8400f67837', '9ecd8c99-4036-403d-bf84-cf8400f67836',
        '0ecd8c99-4036-403d-bf84-cf8400f67836',
        'Pump with titanium frame and nickel wheels for high-strength applications.'),
       ('0ecd8c99-4036-403d-bf84-cf8400f67838', 'Pump 5', 100.0, 10.0, 50.0, 'e.jpg', 'image_data', 5500.00,
        '0ecd8c99-4036-403d-bf84-cf8400f67837', '0ecd8c99-4036-403d-bf84-cf8400f67836',
        '7ecd8c99-4036-403d-bf84-cf8400f67836',
        'Pump with nickel frame and aluminum wheels for durability and corrosion resistance.');