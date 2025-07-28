export type User = {
    email: string;
    firstName: string;
    lastName: string;
    address: Address;
}

export type Address = {
   
    line1: string;
    line2: string;
    city: string;
    state: string;
    country: string;
    postalCode: string;
}