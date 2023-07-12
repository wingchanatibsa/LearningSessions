//
//  BreedsListResponse.swift
//  DogBreedsApp
//
//  Created by Wing on 7/10/23.
//

import Foundation

struct BreedsListResponse : Codable {
    let message: [String:[String]]
    
    private enum CodingKeys: String, CodingKey {
        case message
    }
}
