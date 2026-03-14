-- ============================================================
-- Database: OOO "Obuv" (Shoe Store)
-- Platform: Microsoft SQL Server
-- ============================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Obuv')
    DROP DATABASE Obuv;
GO

CREATE DATABASE Obuv;
GO

USE Obuv;
GO


-- Table: roles
CREATE TABLE roles (
    role_id   INT          NOT NULL IDENTITY(1,1),
    role_name NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_roles PRIMARY KEY (role_id),
    CONSTRAINT UQ_roles_name UNIQUE (role_name)
);
GO


-- Table: users
CREATE TABLE users (
    user_id     INT           NOT NULL IDENTITY(1,1),
    login       NVARCHAR(100) NOT NULL,
    password    NVARCHAR(255) NOT NULL,
    last_name   NVARCHAR(100) NOT NULL,
    first_name  NVARCHAR(100) NOT NULL,
    middle_name NVARCHAR(100) NULL,
    role_id     INT           NOT NULL,
    CONSTRAINT PK_users PRIMARY KEY (user_id),
    CONSTRAINT UQ_users_login UNIQUE (login),
    CONSTRAINT FK_users_role FOREIGN KEY (role_id)
        REFERENCES roles (role_id)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

-- Table: categories
CREATE TABLE categories (
    category_id   INT           NOT NULL IDENTITY(1,1),
    category_name NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_categories PRIMARY KEY (category_id),
    CONSTRAINT UQ_categories_name UNIQUE (category_name)
);
GO

-- Table: manufacturers
CREATE TABLE manufacturers (
    manufacturer_id   INT           NOT NULL IDENTITY(1,1),
    manufacturer_name NVARCHAR(150) NOT NULL,
    CONSTRAINT PK_manufacturers PRIMARY KEY (manufacturer_id),
    CONSTRAINT UQ_manufacturers_name UNIQUE (manufacturer_name)
);
GO

-- Table: suppliers
CREATE TABLE suppliers (
    supplier_id   INT           NOT NULL IDENTITY(1,1),
    supplier_name NVARCHAR(150) NOT NULL,
    CONSTRAINT PK_suppliers PRIMARY KEY (supplier_id),
    CONSTRAINT UQ_suppliers_name UNIQUE (supplier_name)
);
GO

-- Table: units
CREATE TABLE units (
    unit_id   INT          NOT NULL IDENTITY(1,1),
    unit_name NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_units PRIMARY KEY (unit_id),
    CONSTRAINT UQ_units_name UNIQUE (unit_name)
);
GO

-- Table: products
CREATE TABLE products (
    product_id      INT            NOT NULL IDENTITY(1,1),
    product_name    NVARCHAR(200)  NOT NULL,
    category_id     INT            NOT NULL,
    description     NVARCHAR(MAX)  NULL,
    manufacturer_id INT            NOT NULL,
    supplier_id     INT            NOT NULL,
    price           DECIMAL(10, 2) NOT NULL,
    unit_id         INT            NOT NULL,
    stock_quantity  INT            NOT NULL DEFAULT 0,
    discount        DECIMAL(5, 2)  NOT NULL DEFAULT 0,
    image_path      NVARCHAR(500)  NULL,
    CONSTRAINT PK_products PRIMARY KEY (product_id),
    CONSTRAINT CK_products_price        CHECK (price >= 0),
    CONSTRAINT CK_products_stock        CHECK (stock_quantity >= 0),
    CONSTRAINT CK_products_discount     CHECK (discount >= 0 AND discount <= 100),
    CONSTRAINT FK_products_category     FOREIGN KEY (category_id)
        REFERENCES categories (category_id) ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT FK_products_manufacturer FOREIGN KEY (manufacturer_id)
        REFERENCES manufacturers (manufacturer_id) ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT FK_products_supplier     FOREIGN KEY (supplier_id)
        REFERENCES suppliers (supplier_id) ON UPDATE CASCADE ON DELETE NO ACTION,
    CONSTRAINT FK_products_unit         FOREIGN KEY (unit_id)
        REFERENCES units (unit_id) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

-- Table: order_statuses
CREATE TABLE order_statuses (
    status_id   INT           NOT NULL IDENTITY(1,1),
    status_name NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_order_statuses PRIMARY KEY (status_id),
    CONSTRAINT UQ_order_statuses_name UNIQUE (status_name)
);
GO

-- Table: orders
CREATE TABLE orders (
    order_id       INT           NOT NULL IDENTITY(1,1),
    article_number NVARCHAR(50)  NOT NULL,
    status_id      INT           NOT NULL,
    pickup_address NVARCHAR(300) NOT NULL,
    order_date     DATE          NOT NULL,
    issue_date     DATE          NULL,
    CONSTRAINT PK_orders PRIMARY KEY (order_id),
    CONSTRAINT UQ_orders_article UNIQUE (article_number),
    CONSTRAINT FK_orders_status FOREIGN KEY (status_id)
        REFERENCES order_statuses (status_id) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO

-- Table: order_items
CREATE TABLE order_items (
    order_item_id  INT            NOT NULL IDENTITY(1,1),
    order_id       INT            NOT NULL,
    product_id     INT            NOT NULL,
    quantity       INT            NOT NULL,
    price_at_order DECIMAL(10, 2) NOT NULL,
    CONSTRAINT PK_order_items PRIMARY KEY (order_item_id),
    CONSTRAINT CK_order_items_qty   CHECK (quantity > 0),
    CONSTRAINT CK_order_items_price CHECK (price_at_order >= 0),
    CONSTRAINT FK_order_items_order FOREIGN KEY (order_id)
        REFERENCES orders (order_id) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_order_items_product FOREIGN KEY (product_id)
        REFERENCES products (product_id) ON UPDATE NO ACTION ON DELETE NO ACTION
);
GO

-- Seed Data
INSERT INTO roles (role_name) VALUES
    (N'Администратор'), (N'Менеджер'), (N'Клиент');
GO

INSERT INTO order_statuses (status_name) VALUES
    (N'Новый'), (N'В обработке'), (N'Доставляется'),
    (N'Готов к выдаче'), (N'Выдан'), (N'Отменён');
GO

INSERT INTO units (unit_name) VALUES (N'пара'), (N'штука');
GO

INSERT INTO categories (category_name) VALUES
    (N'Кроссовки'), (N'Ботинки'), (N'Туфли'),
    (N'Сапоги'), (N'Сандалии'), (N'Мокасины'), (N'Балетки');
GO

INSERT INTO manufacturers (manufacturer_name) VALUES
    (N'Nike'), (N'Adidas'), (N'Ecco'), (N'Tamaris'), (N'Rieker');
GO

INSERT INTO suppliers (supplier_name) VALUES
    (N'ООО СпортОпт'), (N'ИП Кожевников'),
    (N'АО ОбувьТорг'), (N'ООО МодаОпт');
GO

INSERT INTO users (login, password, last_name, first_name, middle_name, role_id) VALUES
    (N'admin',    N'admin123',   N'Иванов',  N'Иван',    N'Иванович',   1),
    (N'manager1', N'manager123', N'Петрова', N'Мария',   N'Сергеевна',  2),
    (N'client1',  N'client123',  N'Сидоров', N'Алексей', N'Николаевич', 3);
GO

INSERT INTO products (product_name, category_id, description, manufacturer_id, supplier_id, price, unit_id, stock_quantity, discount, image_path) VALUES
    (N'Nike Air Max 90',    1, N'Классические кроссовки с технологией Air Max',    1, 1,  7999.00, 1, 15,  0.00, NULL),
    (N'Adidas Superstar',   1, N'Легендарные кроссовки с фирменными полосками',    2, 1,  6499.00, 1,  8, 10.00, NULL),
    (N'Ecco Soft 7',        3, N'Удобные кожаные туфли для повседневной носки',    3, 2, 12500.00, 1,  5, 20.00, NULL),
    (N'Tamaris Ankle Boot', 4, N'Элегантные женские сапоги на каблуке',            4, 3,  8900.00, 1,  0,  0.00, NULL),
    (N'Rieker Sandal',      5, N'Лёгкие летние сандалии с анатомической стелькой', 5, 4,  3200.00, 1, 20,  5.00, NULL);
GO

INSERT INTO orders (article_number, status_id, pickup_address, order_date, issue_date) VALUES
    (N'ORD-2024-001', 5, N'г. Москва, ул. Ленина, д. 1',            '2024-01-10', '2024-01-15'),
    (N'ORD-2024-002', 4, N'г. Санкт-Петербург, пр. Невский, д. 50', '2024-01-20', NULL),
    (N'ORD-2024-003', 1, N'г. Казань, ул. Баумана, д. 12',          '2024-02-01', NULL);
GO

INSERT INTO order_items (order_id, product_id, quantity, price_at_order) VALUES
    (1, 1, 1, 7999.00),
    (1, 5, 2, 3200.00),
    (2, 3, 1, 10000.00),
    (3, 2, 1,  6499.00);
GO
