
// Value object
Occupancy
    in
    out
    occupancy
        in - out
    add(Occupancy other)
        new Occupancy(this.in + other.in, this.out + other.out)


// Entity
Camera
    ip
    name
    last_updated
    serial
    occupancy
    update(Occupancy) // no side effects

// Entity
Zone
    - cameras : [Camera]
    occupancy()
        cameras.map( _ => _.occupancy).reduce( _ => _.add)


// Service
RefreshOccupancy
    - httpclient
    +update()

@service
Dashboard



---








@repository

Cameras

-httpclient

+all() : [Camera]

+update(Camera) // DB query happens here



@repository

Zones

-Cameras

+all() : [Zone]

+update(Zone) // DB query happens here



@service

RefreshOccupancy

-httpclient

+update(Zone) // DB query happens here



@service

Dashboard