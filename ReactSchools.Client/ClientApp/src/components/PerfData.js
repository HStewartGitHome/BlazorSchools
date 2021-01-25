import React, { Component } from 'react';

export class PerfData extends Component {
    static displayName = PerfData.name;

    constructor(props) {
        super(props);
        this.state = { Performances: [], loading: true };
    }

    componentDidMount() {
        this.populatePerformanceData();
    }

    static renderPerformanceTable(performances) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Performance</th>
                        <th>Update</th>
                        <th>Read</th>
                        <th>Read2</th>
                    </tr>
                </thead>
                <tbody>
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Initialize Performance</td>
                            <td></td>
                            <td>{performance.initPerformance}</td>
                            <td></td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Json Performance</td>
                            <td></td>
                            <td>{performance.jsonPerformance}</td>
                            <td>{performance.jsonPerformance2}</td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Dapper Performance</td>
                            <td>{performance.dapperUpdatePerformance}</td>
                            <td>{performance.dapperPerformance}</td>
                            <td>{performance.dapperPerformance2}</td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Entity Framework Performance</td>
                            <td>{performance.efUpdatePerformance}</td>
                            <td>{performance.efPerformance}</td>
                            <td>{performance.efPerformance2}</td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Use Simulated</td>
                            <td></td>
                            <td>{performance.useSIM}</td>
                            <td></td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Use Dapper Framework</td>
                            <td></td>
                            <td>{performance.useDapper}</td>
                            <td></td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Use Entity Framework</td>
                            <td></td>
                            <td>{performance.useEF}</td>
                            <td></td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Allow Dapper Framework</td>
                            <td></td>
                            <td>{performance.allowDapper}</td>
                            <td></td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Allow Entity Framework</td>
                            <td></td>
                            <td>{performance.allowEF}</td>
                            <td></td>
                        </tr>
                    )}
                    {performances.map(performance =>
                        <tr key={Performance.id}>
                            <td>Max Records</td>
                            <td>{performance.maxPage}</td>
                            <td>{performance.records}</td>
                            <td></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : PerfData.renderPerformanceTable(this.state.Performances);

        return (
            <div>
                <h1 id="tabelLabel" >School API Performance in React</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populatePerformanceData() {
        const response = await fetch('performance');
        const data = await response.json();
        this.setState({ Performances: data, loading: false });
    }
}
