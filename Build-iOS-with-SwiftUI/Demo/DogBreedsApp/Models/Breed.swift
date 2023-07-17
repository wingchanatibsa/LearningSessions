//
//  Breed.swift
//  DogBreedsApp
//
//  Created by Wing on 7/10/23.
//

import Foundation

struct Breed: Codable, Identifiable, Comparable {
    var id = UUID()
    let name: String
    
    static func < (lhs: Breed, rhs: Breed) -> Bool{
        return lhs.name < rhs.name
    }
    
    static func > (lhs: Breed, rhs: Breed) -> Bool{
        return lhs.name > rhs.name
    }
}
