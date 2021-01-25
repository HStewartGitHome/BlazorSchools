import React, { Component } from 'react';

export class SchoolData extends Component {
    static displayName = SchoolData.name;

    constructor(props) {
        super(props);
        this.state = { Schools: [], loading: true };
    }

    componentDidMount() {
        this.populateSchoolData();
    }

    static renderSchoolTable(schools) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Street</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Zip</th>
                    </tr>
                </thead>
                <tbody>
                    {schools.map(school =>
                        <tr key={Performance.id}>
                            <td>{school.name}</td>
                            <td>{school.street}</td>
                            <td>{school.city}</td>
                            <td>{school.state}</td>
                            <td>{school.zip}</td>
                        </tr>
                    )}
                  
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : SchoolData.renderSchoolTable(this.state.Schools);

        return (
            <div>
                <h1 id="tabelLabel" >School API Data in React</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateSchoolData() {
        const response = await fetch('schooldata');
        const data = await response.json();
        this.setState({ Schools: data, loading: false });
    }
}
