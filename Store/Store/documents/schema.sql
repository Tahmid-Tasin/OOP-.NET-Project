create table dbo.admin_table
(
    id        int identity
        primary key,
    firstName varchar(50),
    lastName  varchar(50),
    userName  varchar(100),
    mobile    varchar(20),
    password  varchar(20)
)
go

create table dbo.category
(
    id   int identity
        primary key,
    name varchar(80) not null
        unique
)
go

create table dbo.customer
(
    id         int identity
        primary key,
    full_name  varchar(100)                       not null,
    mobile     varchar(20)                        not null
        unique,
    email      varchar(120)
        unique,
    address    varchar(200),
    password   varchar(100)                       not null,
    is_vip     bit       default 0                not null,
    created_at datetime2 default sysutcdatetime() not null
)
go

create table dbo.cart
(
    id          int identity
        primary key,
    customer_id int                                not null
        unique
        references dbo.customer,
    created_at  datetime2 default sysutcdatetime() not null
)
go

create table dbo.employee
(
    id       int identity
        primary key,
    name     varchar(50),
    mobile   varchar(20),
    password varchar(20),
    address  varchar(100)
)
go

create table dbo.[order]
(
    id                     int identity
        primary key,
    customer_id            int                                     not null
        references dbo.customer,
    order_date             datetime2      default sysutcdatetime() not null,
    status                 varchar(20)    default 'PENDING'        not null,
    approved_by_manager_id int
        references dbo.employee,
    approved_at            datetime2,
    subtotal_amount        decimal(12, 2) default 0                not null,
    discount_amount        decimal(12, 2) default 0                not null,
    total_amount           decimal(12, 2) default 0                not null
)
go

create table dbo.payment
(
    id       int identity
        primary key,
    order_id int                           not null
        references dbo.[order]
            on delete cascade,
    method   varchar(20)                   not null,
    status   varchar(20) default 'PENDING' not null,
    amount   decimal(12, 2)                not null
        check ([amount] >= 0),
    paid_at  datetime2,
    ref_no   varchar(100)
)
go

create table dbo.product
(
    id          int identity
        primary key,
    category_id int            not null
        references dbo.category,
    name        varchar(120)   not null,
    price       decimal(12, 2) not null
        check ([price] >= 0),
    stock_qty   int default 0  not null
        check ([stock_qty] >= 0),
    is_active   bit default 1  not null
)
go

create table dbo.cart_item
(
    id         int identity
        primary key,
    cart_id    int not null
        references dbo.cart
            on delete cascade,
    product_id int not null
        references dbo.product,
    quantity   int not null
        check ([quantity] > 0)
)
go

create table dbo.offer
(
    id               int identity
        primary key,
    name             varchar(120)  not null,
    discount_percent decimal(5, 2) not null
        check ([discount_percent] >= 0 AND [discount_percent] <= 100),
    start_date       date          not null,
    end_date         date          not null,
    category_id      int
        references dbo.category,
    product_id       int
        references dbo.product,
    is_active        bit default 1 not null
)
go

create table dbo.order_item
(
    id         int identity
        primary key,
    order_id   int            not null
        references dbo.[order]
            on delete cascade,
    product_id int            not null
        references dbo.product,
    quantity   int            not null
        check ([quantity] > 0),
    unit_price decimal(12, 2) not null
        check ([unit_price] >= 0),
    line_total decimal(12, 2) not null
        check ([line_total] >= 0)
)
go

create table dbo.restock_request
(
    id                 int identity
        primary key,
    product_id         int                           not null
        references dbo.product,
    requested_by_mgr   int                           not null
        references dbo.employee,
    quantity_requested int                           not null
        check ([quantity_requested] > 0),
    status             varchar(20) default 'PENDING' not null,
    admin_action_by    int
        references dbo.admin_table,
    admin_action_at    datetime2
)
go

create table dbo.review
(
    id          int identity
        primary key,
    customer_id int                                not null
        references dbo.customer,
    product_id  int
        references dbo.product,
    rating      int
        check ([rating] >= 1 AND [rating] <= 5),
    comment     varchar(600),
    created_at  datetime2 default sysutcdatetime() not null
)
go

create table dbo.vip_request
(
    id                  int identity
        primary key,
    customer_id         int                           not null
        references dbo.customer,
    order_id            int                           not null
        references dbo.[order],
    status              varchar(20) default 'PENDING' not null,
    processed_by_mgr_id int
        references dbo.employee,
    processed_at        datetime2
)
go

