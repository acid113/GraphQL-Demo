/* this prevents a compile error when getting a dynamic JSON data
- https://stackoverflow.com/questions/52588576/angular6-upgrade-issue-property-data-does-not-exist-on-type-object
*/

export interface CustomDataResponse {
    data: any;
}
