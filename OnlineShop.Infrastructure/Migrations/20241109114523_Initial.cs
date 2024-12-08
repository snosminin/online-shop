﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnlineShop.Core.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AspNetRoles",
            columns: table => new
            {
                Id = table.Column<string>(type: "text", nullable: false),
                Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUsers",
            columns: table => new
            {
                Id = table.Column<string>(type: "text", nullable: false),
                Initials = table.Column<string>(type: "text", nullable: true),
                UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                PasswordHash = table.Column<string>(type: "text", nullable: true),
                SecurityStamp = table.Column<string>(type: "text", nullable: true),
                ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                PhoneNumber = table.Column<string>(type: "text", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                LockoutEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "discount",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                description = table.Column<string>(type: "text", nullable: true),
                value = table.Column<decimal>(type: "numeric", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("discount_pkey", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "product_category",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                description = table.Column<string>(type: "text", nullable: true),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("product_category_pkey", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetRoleClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                RoleId = table.Column<string>(type: "text", nullable: false),
                ClaimType = table.Column<string>(type: "text", nullable: true),
                ClaimValue = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "AspNetRoles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                UserId = table.Column<string>(type: "text", nullable: false),
                ClaimType = table.Column<string>(type: "text", nullable: true),
                ClaimValue = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserLogins",
            columns: table => new
            {
                LoginProvider = table.Column<string>(type: "text", nullable: false),
                ProviderKey = table.Column<string>(type: "text", nullable: false),
                ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                UserId = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                table.ForeignKey(
                    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserRoles",
            columns: table => new
            {
                UserId = table.Column<string>(type: "text", nullable: false),
                RoleId = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "AspNetRoles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserTokens",
            columns: table => new
            {
                UserId = table.Column<string>(type: "text", nullable: false),
                LoginProvider = table.Column<string>(type: "text", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                Value = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                table.ForeignKey(
                    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "order_detail",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                user_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                total = table.Column<decimal>(type: "numeric", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("order_detail_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_order_detail_aspnetusers",
                    column: x => x.user_id,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "shopping_session",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                user_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("shopping_session_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_shopping_session_aspnetusers",
                    column: x => x.user_id,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "user_payment",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                payment_type = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                provider = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                account_no = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                user_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("user_payment_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_user_payment_aspnetusers",
                    column: x => x.user_id,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "product",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                description = table.Column<string>(type: "text", nullable: true),
                product_category_id = table.Column<int>(type: "integer", nullable: false),
                discount_id = table.Column<int>(type: "integer", nullable: false),
                price = table.Column<decimal>(type: "numeric", nullable: false),
                quantity = table.Column<int>(type: "integer", nullable: false),
                sku = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("product_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_product_discount",
                    column: x => x.discount_id,
                    principalTable: "discount",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "fk_product_product_category",
                    column: x => x.product_category_id,
                    principalTable: "product_category",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "payment_detail",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                order_detail_id = table.Column<int>(type: "integer", nullable: false),
                amount = table.Column<decimal>(type: "numeric", nullable: false),
                provider = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                status = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("payment_detail_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_payment_detail_order_detail",
                    column: x => x.order_detail_id,
                    principalTable: "order_detail",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "cart_item",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                quantity = table.Column<int>(type: "integer", nullable: false),
                shopping_session_id = table.Column<int>(type: "integer", nullable: false),
                product_id = table.Column<int>(type: "integer", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("cart_item_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_cart_item_product",
                    column: x => x.product_id,
                    principalTable: "product",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "fk_cart_item_shopping_session",
                    column: x => x.shopping_session_id,
                    principalTable: "shopping_session",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "comment",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                comment = table.Column<string>(type: "text", nullable: false),
                user_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                product_id = table.Column<int>(type: "integer", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("comment_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_comment_aspnetusers",
                    column: x => x.user_id,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "fk_comment_product",
                    column: x => x.product_id,
                    principalTable: "product",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "order_item",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                quantity = table.Column<int>(type: "integer", nullable: false),
                order_detail_id = table.Column<int>(type: "integer", nullable: false),
                product_id = table.Column<int>(type: "integer", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("order_item_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_order_item_order_detail",
                    column: x => x.order_detail_id,
                    principalTable: "order_detail",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "fk_order_item_product",
                    column: x => x.product_id,
                    principalTable: "product",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "product_attachment",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                data = table.Column<byte[]>(type: "bytea", nullable: false),
                product_id = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("product_attachment_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_product_image_product",
                    column: x => x.product_id,
                    principalTable: "product",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "wishlist",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                user_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                product_id = table.Column<int>(type: "integer", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("wishlist_pkey", x => x.id);
                table.ForeignKey(
                    name: "fk_wishlist_aspnetusers",
                    column: x => x.user_id,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "fk_wishlist_product",
                    column: x => x.product_id,
                    principalTable: "product",
                    principalColumn: "id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_AspNetRoleClaims_RoleId",
            table: "AspNetRoleClaims",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "RoleNameIndex",
            table: "AspNetRoles",
            column: "NormalizedName",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserClaims_UserId",
            table: "AspNetUserClaims",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserLogins_UserId",
            table: "AspNetUserLogins",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserRoles_RoleId",
            table: "AspNetUserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "EmailIndex",
            table: "AspNetUsers",
            column: "NormalizedEmail");

        migrationBuilder.CreateIndex(
            name: "UserNameIndex",
            table: "AspNetUsers",
            column: "NormalizedUserName",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_cart_item_product_id",
            table: "cart_item",
            column: "product_id");

        migrationBuilder.CreateIndex(
            name: "IX_cart_item_shopping_session_id",
            table: "cart_item",
            column: "shopping_session_id");

        migrationBuilder.CreateIndex(
            name: "IX_comment_product_id",
            table: "comment",
            column: "product_id");

        migrationBuilder.CreateIndex(
            name: "IX_comment_user_id",
            table: "comment",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "discount_name_key",
            table: "discount",
            column: "name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_order_detail_user_id",
            table: "order_detail",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_order_item_order_detail_id",
            table: "order_item",
            column: "order_detail_id");

        migrationBuilder.CreateIndex(
            name: "IX_order_item_product_id",
            table: "order_item",
            column: "product_id");

        migrationBuilder.CreateIndex(
            name: "IX_payment_detail_order_detail_id",
            table: "payment_detail",
            column: "order_detail_id");

        migrationBuilder.CreateIndex(
            name: "IX_product_discount_id",
            table: "product",
            column: "discount_id");

        migrationBuilder.CreateIndex(
            name: "IX_product_product_category_id",
            table: "product",
            column: "product_category_id");

        migrationBuilder.CreateIndex(
            name: "product_name_key",
            table: "product",
            column: "name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_product_attachment_product_id",
            table: "product_attachment",
            column: "product_id");

        migrationBuilder.CreateIndex(
            name: "product_attachment_name_key",
            table: "product_attachment",
            column: "name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "product_category_name_key",
            table: "product_category",
            column: "name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_shopping_session_user_id",
            table: "shopping_session",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_user_payment_user_id",
            table: "user_payment",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_wishlist_product_id",
            table: "wishlist",
            column: "product_id");

        migrationBuilder.CreateIndex(
            name: "IX_wishlist_user_id",
            table: "wishlist",
            column: "user_id");

        migrationBuilder.Sql(@"
                                    INSERT INTO ""AspNetRoles"" VALUES ('ad1eb680-9ace-407a-bc53-6c37722742db', 'Client', 'CLIENT', NULL) ON CONFLICT DO NOTHING;
                                    
                                    INSERT INTO ""AspNetUsers"" VALUES ('e9966625-a2e7-4d37-bada-64b98ac6af30', NULL, 'user', 'USER', 'user@email.com', 'USER@EMAIL.COM', false, 'AQAAAAIAAYagAAAAEKPtEBPETp9guvUjooeu21Uy6aeaJKnrAcOnLrXCmmlfDiNcZg4u8w1q5V4Evv3sfA==', 'DJW4EXKMFK7H3X5BLK2OIBM4OCUL5CF5', 'cf5fa20b-ffd3-4974-9142-d7746a403a71', NULL, false, false, NULL, true, 0) ON CONFLICT DO NOTHING;

                                    INSERT INTO ""AspNetUserRoles"" VALUES ('e9966625-a2e7-4d37-bada-64b98ac6af30', 'ad1eb680-9ace-407a-bc53-6c37722742db') ON CONFLICT DO NOTHING;
                                    
                                    INSERT INTO discount VALUES (1, 'Salebration', '', 0.1, '2024-11-08 13:15:59.67278', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO discount VALUES (2, 'Discount Derby', '', 0.15, '2024-11-08 13:15:59.67278', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO discount VALUES (3, 'Value Vault', '', 0.12, '2024-11-08 13:15:59.67278', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO discount VALUES (4, 'Sale Fever Frenzy', '', 0.17, '2024-11-08 13:15:59.67278', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO discount VALUES (5, 'VIP Valuables', '', 0.09, '2024-11-08 13:15:59.67278', NULL, NULL) ON CONFLICT DO NOTHING;

                                    INSERT INTO product_category VALUES (1, 'Smartphones', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (2, 'Laptops', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (3, 'Speaker', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (4, 'Television', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (5, 'Cameras', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (6, 'Computers', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (7, 'Power banks', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (8, 'Game consoles', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (9, 'Tablets', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product_category VALUES (10, 'Headphones', '', '2024-11-08 13:15:59.410021', NULL, NULL) ON CONFLICT DO NOTHING;

                                    INSERT INTO product VALUES (1, 'TCL 32-Inch Class S1', ' 1080p LED Smart TV with Fire TV (32S350F, 2023 Model), Alexa Built-in, Apple AirPlay Compatibility, Streaming FHD Television,Black', 1, 1, 1000, 10, 'sku6876876', '2024-11-08 13:15:59.780429', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product VALUES (2, 'TCL 32-Inch Class S2', ' 1080p LED Smart TV with Fire TV (32S350F, 2023 Model), Alexa Built-in, Apple AirPlay Compatibility, Streaming FHD Television,Black', 1, 1, 1000, 10, 'sku6876876', '2024-11-08 13:15:59.780429', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product VALUES (3, 'TCL 32-Inch Class S3', ' 1080p LED Smart TV with Fire TV (32S350F, 2023 Model), Alexa Built-in, Apple AirPlay Compatibility, Streaming FHD Television,Black', 1, 1, 1000, 10, 'sku6876876', '2024-11-08 13:15:59.780429', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product VALUES (4, 'TCL 32-Inch Class S4', ' 1080p LED Smart TV with Fire TV (32S350F, 2023 Model), Alexa Built-in, Apple AirPlay Compatibility, Streaming FHD Television,Black', 1, 1, 1000, 10, 'sku6876876', '2024-11-08 13:15:59.780429', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product VALUES (5, 'TCL 32-Inch Class S5', ' 1080p LED Smart TV with Fire TV (32S350F, 2023 Model), Alexa Built-in, Apple AirPlay Compatibility, Streaming FHD Television,Black', 1, 1, 1000, 10, 'sku6876876', '2024-11-08 13:15:59.780429', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product VALUES (6, 'TCL 32-Inch Class S6', ' 1080p LED Smart TV with Fire TV (32S350F, 2023 Model), Alexa Built-in, Apple AirPlay Compatibility, Streaming FHD Television,Black', 1, 1, 1000, 10, 'sku6876876', '2024-11-08 13:15:59.780429', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product VALUES (7, 'TCL 32-Inch Class S7', ' 1080p LED Smart TV with Fire TV (32S350F, 2023 Model), Alexa Built-in, Apple AirPlay Compatibility, Streaming FHD Television,Black', 1, 1, 1000, 10, 'sku6876876', '2024-11-08 13:15:59.780429', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO product VALUES (8, 'TCL 32-Inch Class S8', ' 1080p LED Smart TV with Fire TV (32S350F, 2023 Model), Alexa Built-in, Apple AirPlay Compatibility, Streaming FHD Television,Black', 1, 1, 1000, 10, 'sku6876876', '2024-11-08 13:15:59.780429', NULL, NULL) ON CONFLICT DO NOTHING;
                                    
                                    INSERT INTO shopping_session VALUES (1, 'e9966625-a2e7-4d37-bada-64b98ac6af30', '2024-11-08 13:16:00.128215', NULL) ON CONFLICT DO NOTHING;

                                    INSERT INTO cart_item VALUES (1, 1, 1, 1, '2024-11-08 13:16:00.329784', NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO cart_item VALUES (2, 2, 1, 2, '2024-11-08 13:16:00.329784', NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO cart_item VALUES (3, 3, 1, 3, '2024-11-08 13:16:00.329784', NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO cart_item VALUES (4, 4, 1, 4, '2024-11-08 13:16:00.329784', NULL) ON CONFLICT DO NOTHING;

                                    INSERT INTO wishlist VALUES (1, 'e9966625-a2e7-4d37-bada-64b98ac6af30', 1, '2024-11-08 13:15:59.959676', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO wishlist VALUES (2, 'e9966625-a2e7-4d37-bada-64b98ac6af30', 2, '2024-11-08 13:15:59.959676', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO wishlist VALUES (3, 'e9966625-a2e7-4d37-bada-64b98ac6af30', 3, '2024-11-08 13:15:59.959676', NULL, NULL) ON CONFLICT DO NOTHING;
                                    INSERT INTO wishlist VALUES (4, 'e9966625-a2e7-4d37-bada-64b98ac6af30', 4, '2024-11-08 13:15:59.959676', NULL, NULL) ON CONFLICT DO NOTHING;
        ");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AspNetRoleClaims");

        migrationBuilder.DropTable(
            name: "AspNetUserClaims");

        migrationBuilder.DropTable(
            name: "AspNetUserLogins");

        migrationBuilder.DropTable(
            name: "AspNetUserRoles");

        migrationBuilder.DropTable(
            name: "AspNetUserTokens");

        migrationBuilder.DropTable(
            name: "cart_item");

        migrationBuilder.DropTable(
            name: "comment");

        migrationBuilder.DropTable(
            name: "order_item");

        migrationBuilder.DropTable(
            name: "payment_detail");

        migrationBuilder.DropTable(
            name: "product_attachment");

        migrationBuilder.DropTable(
            name: "user_payment");

        migrationBuilder.DropTable(
            name: "wishlist");

        migrationBuilder.DropTable(
            name: "AspNetRoles");

        migrationBuilder.DropTable(
            name: "shopping_session");

        migrationBuilder.DropTable(
            name: "order_detail");

        migrationBuilder.DropTable(
            name: "product");

        migrationBuilder.DropTable(
            name: "AspNetUsers");

        migrationBuilder.DropTable(
            name: "discount");

        migrationBuilder.DropTable(
            name: "product_category");
    }
}