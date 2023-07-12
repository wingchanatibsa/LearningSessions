//
//  RandomImageResponse.swift
//  DogBreedsApp
//
//  Created by Wing on 7/10/23.
//

import Foundation
struct RandomImageResponse: Codable {
    let message : String
    
    private enum CodingKeys: String, CodingKey {
        case message
    }
}
