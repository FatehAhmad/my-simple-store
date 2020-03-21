using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetProductsMVC.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Version { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public List<ProductFile> Files { get; set; }
        public string PaymentMethod { get; set; }
        public ProductBasePrice BasePrice { get; set; }
        public ProductBaseReward BaseReward { get; set; }
        public ProductInventory Inventory { get; set; }
        public ProductPrice Price { get; set; }



        //{
        //    "productId": "catalog:products:459:b",
        //    "version": "A:23268-grDXCMWPC0+8rMS4q07j5g, B:23265-Ut7/KWGv00iLUl4cbZM9oA",
        //    "slug": "a-samsung-112",
        //    "title": "A Samsung 11",
        //    "description": "long description\n\nsomehow I need to do that \n\nhopefully, it doesn't bounce",
        //    "titles": {},
        //    "descriptions": {},
        //    "isActive": true,
        //    "status": "Available",
        //    "files": [
        //        {
        //            "fileId": "assets:files:1:b",
        //            "contentType": "image/jpeg",
        //            "accessPermission": "Public",
        //            "accessUrl": "77ec871a-c073-43c3-9685-cf17312770c1/2005-holden-monaro-cv8-z_5.jpg",
        //            "attributes": {
        //                "isHeroImage": true,
        //                "category_image": "true"
        //            },
        //            "edgeUrl": "https://images.simplestore.dev"
        //        },
        //        {
        //            "fileId": "assets:files:33:b",
        //            "contentType": "image/jpeg",
        //            "accessPermission": "Private",
        //            "accessUrl": "77ec871a-c073-43c3-9685-cf17312770c1/300200_1.jpg",
        //            "attributes": {
        //                "test": "test"
        //            },
        //            "edgeUrl": "https://images.simplestore.dev"
        //        },
        //        {
        //            "fileId": "assets:files:66:b",
        //            "contentType": "image/png",
        //            "accessPermission": "Public",
        //            "accessUrl": "77ec871a-c073-43c3-9685-cf17312770c1/logo.png",
        //            "attributes": {},
        //            "edgeUrl": "https://images.simplestore.dev"
        //        },
        //        {
        //            "fileId": "assets:files:98:b",
        //            "contentType": "image/jpeg",
        //            "accessPermission": "Public",
        //            "accessUrl": "77ec871a-c073-43c3-9685-cf17312770c1/img-20190711-wa0000.jpg",
        //            "attributes": {
        //                "isHeroImage": "true"
        //            },
        //            "edgeUrl": "https://images.simplestore.dev"
        //        },
        //        {
        //            "fileId": "assets:files:65:b",
        //            "contentType": "image/jpeg",
        //            "accessPermission": "Public",
        //            "accessUrl": "77ec871a-c073-43c3-9685-cf17312770c1/2005-holden-monaro-cv8-z_9.jpg",
        //            "attributes": {},
        //            "edgeUrl": "https://images.simplestore.dev"
        //        },
        //        {
        //            "fileId": "assets:files:353:b",
        //            "contentType": "image/jpeg",
        //            "accessPermission": "Public",
        //            "accessUrl": "77ec871a-c073-43c3-9685-cf17312770c1/15737247448475504542393224813498.jpg",
        //            "attributes": {},
        //            "edgeUrl": "https://images.simplestore.dev"
        //        },
        //        {
        //            "fileId": "assets:files:389:a",
        //            "contentType": "image/jpeg",
        //            "accessPermission": "Public",
        //            "accessUrl": "77ec871a-c073-43c3-9685-cf17312770c1/15792429551686678685964387581815.jpg",
        //            "attributes": {},
        //            "edgeUrl": "https://images.simplestore.dev"
        //        }
        //    ],
        //    "paymentMethod": "RewardsPlusPay",
        //    "basePrice": {
        //        "currencyCode": "AUD",
        //        "sellPrice": 29.95,
        //        "retailPrice": 35.99,
        //        "attributes": {}
        //    },
        //    "baseRewards": {
        //        "isEnabled": true,
        //        "points": 40000,
        //        "minPayAmount": 25.0,
        //        "minPointsAmount": 1000.0
        //    },
        //    "price": {
        //        "currencyCode": "AUD",
        //        "sellPrice": 29.95,
        //        "retailPrice": 35.99,
        //        "attributes": {}
        //    },
        //    "rewards": {
        //        "isEnabled": true,
        //        "points": 40000,
        //        "minPayAmount": 25.0,
        //        "minPointsAmount": 1000.0
        //    },
        //    "inventory": {
        //        "sku": "ITM0011",
        //        "availableQuantity": 110.0,
        //        "minActiveQuantity": 3.0,
        //        "grossWeight": null,
        //        "trackInventory": true
        //    },
        //    "attributes": {
        //        "color": "red",
        //        "size": "kl",
        //        "width": "test",
        //        "Size": "Large",
        //        "Title": "Hello"
        //    },
        //    "categories": [
        //        {
        //            "key": "catalog:categories:193:b",
        //            "title": "Top",
        //            "slug": "top-1-2-3-4-5-6-7-8-9-10-11-12-13-14",
        //            "isActive": true
        //        },
        //        {
        //            "key": "catalog:categories:194:b",
        //            "title": "Milk",
        //            "slug": null,
        //            "isActive": true
        //        }
        //    ],
        //    "collections": [
        //        {
        //            "key": "catalog:collections:33:b",
        //            "title": "Father's Day Specials",
        //            "slug": "fathers-day-specials",
        //            "isActive": true
        //        },
        //        {
        //            "key": "catalog:collections:1:b",
        //            "title": "Weekend Special",
        //            "slug": "weekend-special",
        //            "isActive": true
        //        }
        //    ]
        //},
    }
}
